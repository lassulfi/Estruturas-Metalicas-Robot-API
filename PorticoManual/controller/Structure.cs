using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotOM;
using PorticoManual.model;
using PorticoManual.util;

namespace PorticoManual.controller
{
    class Structure
    {
        //Atributes
        private IRobotApplication iRobotApp;

        private static Structure instance = new Structure();

        private List<Node> nodes;
        private List<Bar> bars;

        public IRobotLabel labels { get; private set; }

        private bool geometryCreated = false;
        private bool loadsGenerated = false;

        //Constructor
        private Structure()
        {
            iRobotApp = new RobotApplicationClass();
        }

        public static Structure getInstance()
        {
            return instance;
        }

        //Methods

        //Create a new 3D project
        public void createProject()
        {
            if (iRobotApp.Project.IsActive == 0)
            {
                iRobotApp.Project.New(IRobotProjectType.I_PT_FRAME_3D);
            }

        }//createProject

        //Returns the label server
        public IRobotLabelServer getLabelServer()
        {
            return (RobotLabelServer)iRobotApp.Project.Structure.Labels;
        }//getLabelServer

        //Load a section database from Robot
        private IRobotSectionDatabase getSectionDatabase(string database)
        {
            //Change the database
            setCurrentDatabase(IRobotDatabaseType.I_DT_SECTIONS, database);
            //Retrive the list of all databases
            IRobotSectionDatabaseList dbSectionList = (RobotSectionDatabaseList)iRobotApp.Project.Preferences.SectionsActive;

            IRobotSectionDatabase dbSection = null;

            for (int i = 0; i < dbSectionList.Count; i++)
            {
                if (dbSectionList.GetDatabase(i).Name.Equals(database))
                {
                    dbSection = (RobotSectionDatabase)dbSectionList.GetDatabase(i);
                }
            }

            return dbSection;
        }//getSectionDatabase


        public IRobotNamesArray loadProfileDatabase(string database, string type)
        {
            //Access the IRobotLabelServer
            IRobotLabelServer labelServer = getLabelServer();

            //Change the current section database
            string sDBName = database;
            IRobotSectionDatabase sectionDBase = getSectionDatabase(sDBName);

            IRobotNamesArray profiles = (RobotNamesArray)sectionDBase.GetAll();

            RobotNamesArray filtered = new RobotNamesArray();
            int filterSize = 1;

            for (int i = 1; i < profiles.Count; i++)
            {
                //Defines the size of the Array
                //Console.WriteLine(profiles.Get(i));
                if (profiles.Get(i).StartsWith(type))
                {
                    filterSize++;
                }
            }

            //Console.WriteLine(filterSize);
            filtered.SetSize(filterSize);

            //Labeling the filter

            int pos = 1;
            for (int i = 1; i < profiles.Count; i++)
            {
                if (profiles.Get(i).StartsWith(type))
                {
                    filtered.Set(pos, profiles.Get(i));
                    pos++;
                }
            }

            return filtered;
        }//loadProfileDatabase

        //Divide columns into a number of bars
        //Reference: https://forums.autodesk.com/t5/robot-structural-analysis-forum/api-divide-bars/m-p/4422193#M16921
        public void divideColumns(int divisionNumber, string section)
        {
            int firstIsolatedNode = iRobotApp.Project.Structure.Nodes.FreeNumber; //First new created node

            int freeNodeNumber = firstIsolatedNode;

            //Add columns to the selection
            foreach (Bar bar in bars)
            {
                if (bar.type == MemberType.Column)
                {
                    IRobotBar robotBar = (RobotBar)iRobotApp.Project.Structure.Bars.Get(bar.id);
                    IRobotNode startNode = (RobotNode)iRobotApp.Project.Structure.Nodes.Get(bar.startNode.id);
                    IRobotNode endNode = (RobotNode)iRobotApp.Project.Structure.Nodes.Get(bar.endNode.id);

                    //Console.WriteLine("freeNodeNumber: " + freeNodeNumber);
                    //Bar vector
                    double vx, vy, vz, vl;
                    vx = endNode.X - startNode.X;
                    vy = endNode.Y - startNode.Y;
                    vz = endNode.Z - startNode.Z;
                    //Vector length
                    vl = Math.Sqrt(Math.Pow(vx, 2) + Math.Pow(vy, 2) + Math.Pow(vz, 2));
                    //Normalization
                    vx /= vl;
                    vy /= vl;
                    vz /= vl;
                    //distance between nodes
                    double distance = vl / divisionNumber;

                    //Adding new nodes
                    for (int j = 0; j < divisionNumber - 1; j++)
                    {
                        //Add to the list of nodes
                        //Add a new node
                        Node node = new Node(freeNodeNumber,
                                            startNode.X + (j + 1) * vx * distance,
                                            startNode.Y + (j + 1) * vy * distance,
                                            startNode.Z + (j + 1) * vz * distance);
                        //Console.Write("startNode.X = " + startNode.X);
                        //Console.Write(" startNode.Y = " + startNode.Y);
                        //Console.WriteLine(" startNode.Z = " + startNode.Z);
                        //Console.WriteLine("vx: " + vx + " vy: " + vy + " vz: " + vz + " vl: " + vl);

                        //Console.WriteLine("Node id: " + node.id + " x: " + node.xCoord + " y: " + node.yCoord + " z: " + node.zCoord);
                        nodes.Add(node);
                        //Add a node to the structure
                        iRobotApp.Project.Structure.Nodes.Create(freeNodeNumber, node.xCoord, node.yCoord, node.zCoord);
                        freeNodeNumber++;
                    }
                }
            }

            //Creating aditional bars
            int numberOfBars = bars.Count + 1;
            int barIndex = numberOfBars;
            //Console.WriteLine("Number of bars: " + numberOfBars);
            int index = firstIsolatedNode;
            //Console.WriteLine("firstIsolatedNode: " + index);
            for (int i = 0; i < (divisionNumber - 1); i++)
            {
                //Finding the nodes for a line of bars
                IRobotNode iNode1 = (RobotNode)iRobotApp.Project.Structure.Nodes.Get(index);
                //Console.WriteLine("Node 1  - " + iNode1.Number);
                IRobotNode iNode2 = (RobotNode)iRobotApp.Project.Structure.Nodes.Get((index + 2));
                //Console.WriteLine("Node 2  - " + iNode2.Number);
                IRobotNode iNode3 = (RobotNode)iRobotApp.Project.Structure.Nodes.Get((index + 4));
                //Console.WriteLine("Node 3  - " + iNode3.Number);
                IRobotNode iNode4 = (RobotNode)iRobotApp.Project.Structure.Nodes.Get((index + 6));
                //Console.WriteLine("Node 4  - " + iNode4.Number);
                Node node1 = new Node(iNode1.Number, iNode1.X, iNode1.Y, iNode1.Z);
                nodes.Add(node1);
                Node node2 = new Node(iNode2.Number, iNode2.X, iNode2.Y, iNode2.Z);
                nodes.Add(node2);
                Node node3 = new Node(iNode3.Number, iNode3.X, iNode3.Y, iNode3.Z);
                nodes.Add(node3);
                Node node4 = new Node(iNode4.Number, iNode4.X, iNode4.Y, iNode4.Z);
                nodes.Add(node4);
                barIndex += i;
                Bar bar1 = new Bar(barIndex, node1, node2, MemberType.Bar, section);
                bars.Add(bar1);
                //Console.WriteLine("Bar id: " + bar1.id + ", first node id: " + bar1.startNode.id + ", last node id: " + bar1.endNode.id);
                barIndex += 1;
                Bar bar2 = new Bar(barIndex, node1, node3, MemberType.Bar, section);
                bars.Add(bar2);
                //Console.WriteLine("Bar id: " + bar2.id + ", first node id: " + bar2.startNode.id + ", last node id: " + bar2.endNode.id);
                barIndex += 2;
                Bar bar3 = new Bar(barIndex, node2, node4, MemberType.Bar, section);
                //Console.WriteLine("Bar id: " + bar3.id + ", first node id: " + bar3.startNode.id + ", last node id: " + bar3.endNode.id);
                bars.Add(bar3);
                barIndex += 3;
                Bar bar4 = new Bar(barIndex, node3, node4, MemberType.Bar, section);
                bars.Add(bar4);
                //Console.WriteLine("Bar id: " + bar4.id + ", first node id: " + bar4.startNode.id + ", last node id: " + bar4.endNode.id);
                index += 1;
            }
            index += 6;
            barIndex += 1;
            for (int i = 0; i < (divisionNumber - 1); i++)
            {
                //Finding the nodes for a line of bars
                IRobotNode iNode1 = (RobotNode)iRobotApp.Project.Structure.Nodes.Get(index);
                //Console.WriteLine("Node 1  - " + iNode1.Number);
                IRobotNode iNode2 = (RobotNode)iRobotApp.Project.Structure.Nodes.Get((index + 2));
                //Console.WriteLine("Node 2  - " + iNode2.Number);
                IRobotNode iNode3 = (RobotNode)iRobotApp.Project.Structure.Nodes.Get((index + 4));
                //Console.WriteLine("Node 3  - " + iNode3.Number);
                IRobotNode iNode4 = (RobotNode)iRobotApp.Project.Structure.Nodes.Get((index + 6));
                //Console.WriteLine("Node 4  - " + iNode4.Number);
                Node node1 = new Node(iNode1.Number, iNode1.X, iNode1.Y, iNode1.Z);
                nodes.Add(node1);
                Node node2 = new Node(iNode2.Number, iNode2.X, iNode2.Y, iNode2.Z);
                nodes.Add(node2);
                Node node3 = new Node(iNode3.Number, iNode3.X, iNode3.Y, iNode3.Z);
                nodes.Add(node3);
                Node node4 = new Node(iNode4.Number, iNode4.X, iNode4.Y, iNode4.Z);
                nodes.Add(node4);
                barIndex += i;
                Bar bar1 = new Bar(barIndex, node1, node2, MemberType.Bar, section);
                bars.Add(bar1);
                //Console.WriteLine("Bar id: " + bar1.id + ", first node id: " + bar1.startNode.id + ", last node id: " + bar1.endNode.id);
                barIndex += 1;
                Bar bar2 = new Bar(barIndex, node1, node3, MemberType.Bar, section);
                bars.Add(bar2);
                //Console.WriteLine("Bar id: " + bar2.id + ", first node id: " + bar2.startNode.id + ", last node id: " + bar2.endNode.id);
                barIndex += 2;
                Bar bar3 = new Bar(barIndex, node2, node4, MemberType.Bar, section);
                //Console.WriteLine("Bar id: " + bar3.id + ", first node id: " + bar3.startNode.id + ", last node id: " + bar3.endNode.id);
                bars.Add(bar3);
                barIndex += 3;
                Bar bar4 = new Bar(barIndex, node3, node4, MemberType.Bar, section);
                bars.Add(bar4);
                //Console.WriteLine("Bar id: " + bar4.id + ", first node id: " + bar4.startNode.id + ", last node id: " + bar4.endNode.id);
                index += 1;
            }
            addRobotBars(numberOfBars - 1, null, null, null, section);
        }//divideColumns

        //Change the current database
        private void setCurrentDatabase(IRobotDatabaseType dbtype, string database)
        {
            iRobotApp.Project.Preferences.SetCurrentDatabase(dbtype, database);
        }//setCurrentDataBase

        //Store the selected section to the Robot Application
        public void storeSectionLabelFromDB(string database, IRobotLabelType labelType, string section)
        {
            //Access LabelServer
            IRobotLabelServer labelServer = getLabelServer();

            //Get Section DataBase
            setCurrentDatabase(IRobotDatabaseType.I_DT_SECTIONS, database);

            //Create a Label
            IRobotLabel label = labelServer.Create(labelType, section);
            IRobotBarSectionData sectionData = (RobotBarSectionData)label.Data;
            sectionData.LoadFromDBase(section);
            labelServer.Store(label);
        }

        public void createFrame(double g, double d, double b, double c, double e, string railBeam, string column, string wheelBeam)
        {

            //Disable Robot software iteraction with the user
            iRobotApp.Interactive = 0;

            //Create a new 3D Frame
            //iRobotApp.Project.New(IRobotProjectType.I_PT_FRAME_3D);

            //Creating nodes
            nodes = new List<Node>();

            nodes.Add(new Node(1, 0, 0, 0));
            nodes.Add(new Node(2, 0, g, 0));
            nodes.Add(new Node(3, 0, g / 2, (d + b) / 2));
            nodes.Add(new Node(4, (c - e) / 2, g / 2, (d + b) / 2));
            nodes.Add(new Node(5, (c - e) / 2 + e, g / 2, (d + b) / 2));
            nodes.Add(new Node(6, c, g / 2, (d + b) / 2));
            nodes.Add(new Node(7, c, 0, 0));
            nodes.Add(new Node(8, c, g, 0));

            IRobotNodeServer iNodes = iRobotApp.Project.Structure.Nodes;

            RobotSelection supportSelection = iRobotApp.Project.Structure.Selections.Create(IRobotObjectType.I_OT_NODE);
            supportSelection.Clear();

            string supportLabels = getConstraintLabel();

            foreach (Node n in nodes)
            {
                iNodes.Create(n.id, n.xCoord, n.yCoord, n.zCoord);
                //Setting constraint labels
                switch (n.id)
                {
                    case 1:
                    case 2:
                    case 7:
                    case 8:
                        supportSelection.AddOne(n.id);
                        break;
                }
                iNodes.SetLabel(supportSelection, IRobotLabelType.I_LT_SUPPORT, supportLabels);
            }

            //Creating bars

            bars = new List<Bar>();
            bars.Add(new Bar(1, nodes[0], nodes[1], MemberType.WheelBeam));
            bars.Add(new Bar(2, nodes[0], nodes[2], MemberType.Column));
            bars.Add(new Bar(3, nodes[1], nodes[2], MemberType.Column));
            bars.Add(new Bar(4, nodes[0], nodes[3], MemberType.Column));
            bars.Add(new Bar(5, nodes[1], nodes[3], MemberType.Column));
            bars.Add(new Bar(6, nodes[2], nodes[5], MemberType.RailBeam));
            bars.Add(new Bar(7, nodes[6], nodes[4], MemberType.Column));
            bars.Add(new Bar(8, nodes[7], nodes[4], MemberType.Column));
            bars.Add(new Bar(9, nodes[6], nodes[5], MemberType.Column));
            bars.Add(new Bar(10, nodes[7], nodes[5], MemberType.Column));
            bars.Add(new Bar(11, nodes[6], nodes[7], MemberType.WheelBeam));

            addRobotBars(0, column, railBeam, wheelBeam, null);

            //Set the geometry created status to true
            geometryCreated = true;

            //Allow the user to work with Robot Sofware GUI
            iRobotApp.Interactive = 1;
        }//createFrame

        private void addRobotBars(int startIndex, string column, string railBeam, string wheelBeam, string simpleBar)
        {
            IRobotBarServer iBars = iRobotApp.Project.Structure.Bars;
            //Bar selection
            RobotSelection barSelection = iRobotApp.Project.Structure.Selections.Create(IRobotObjectType.I_OT_BAR);

            for (int i = startIndex; i < bars.Count; i++)
            {
                //Create the bars in the Robot Software
                iBars.Create(bars[i].id, bars[i].startNode.id, bars[i].endNode.id);
                //Clear the previous selection
                barSelection.Clear();
                //Add the current bar to the selection
                barSelection.AddOne(bars[i].id);
                //Assign the profile
                switch (bars[i].type)
                {
                    case MemberType.Column:
                        bars[i].sectionLabel = column;
                        break;
                    case MemberType.RailBeam:
                        bars[i].sectionLabel = railBeam;
                        break;
                    case MemberType.WheelBeam:
                        bars[i].sectionLabel = wheelBeam;
                        break;
                    case MemberType.Bar:
                        bars[i].sectionLabel = simpleBar;
                        break;
                    default:
                        break;
                }
                //Setting the label
                iBars.SetLabel(barSelection, IRobotLabelType.I_LT_BAR_SECTION, bars[i].sectionLabel);
            }
        }//addRobotBars

        //Generate the label for constraints in the entire struture
        private string getConstraintLabel()
        {
            IRobotLabel supportLabel = iRobotApp.Project.Structure.Labels.Create(IRobotLabelType.I_LT_SUPPORT, "Apoios");

            IRobotNodeSupportData supports = (RobotNodeSupportData)supportLabel.Data;
            supports.SetFixed(IRobotNodeSupportFixingDirection.I_NSFD_RX, 0);
            supports.SetFixed(IRobotNodeSupportFixingDirection.I_NSFD_RY, 0);
            supports.SetFixed(IRobotNodeSupportFixingDirection.I_NSFD_RZ, 0);
            supports.SetFixed(IRobotNodeSupportFixingDirection.I_NSFD_UX, 1);
            supports.SetFixed(IRobotNodeSupportFixingDirection.I_NSFD_UY, 1);
            supports.SetFixed(IRobotNodeSupportFixingDirection.I_NSFD_UZ, 1);

            iRobotApp.Project.Structure.Labels.Store(supportLabel);

            return supportLabel.Name;
        }//getConstraintLabel

        //Define the unit settings for the project
        public void unitSettings(string length, string sectionDimension)
        {

            //Unit definition data
            IRobotUnitData lengthData = (RobotUnitData)iRobotApp.Project.Preferences.Units.Get(IRobotUnitType.I_UT_STRUCTURE_DIMENSION);
            lengthData.Name = length;
            lengthData.Precision = 1;

            IRobotUnitData sectionDimensionData = (RobotUnitData)iRobotApp.Project.Preferences.Units.Get(IRobotUnitType.I_UT_SECTION_DIMENSION);
            sectionDimensionData.Name = sectionDimension;

            IRobotUnitData sectionPropertiesData = (RobotUnitData)iRobotApp.Project.Preferences.Units.Get(IRobotUnitType.I_UT_SECTION_PROPERTIES);
            sectionPropertiesData.Name = sectionDimension;

            iRobotApp.Project.Preferences.Units.Set(IRobotUnitType.I_UT_STRUCTURE_DIMENSION, (RobotUnitData)lengthData);
            iRobotApp.Project.Preferences.Units.Set(IRobotUnitType.I_UT_SECTION_DIMENSION, (RobotUnitData)sectionDimensionData);
            iRobotApp.Project.Preferences.Units.Set(IRobotUnitType.I_UT_SECTION_PROPERTIES, (RobotUnitData)sectionPropertiesData);

            //Forces the application to change the units
            iRobotApp.Project.Preferences.Units.Refresh();
        }//unitSettings

        //This method creates a concentrated load in a determined position of a beam
        private void createConcentratedLoad(IRobotSimpleCase simpleCase, double position, double value, Bar bar)
        {
            IRobotLoadRecord2 irl = (IRobotLoadRecord2)simpleCase.Records.Create(IRobotLoadRecordType.I_LRT_BAR_FORCE_CONCENTRATED);

            irl.SetValue((short)IRobotBarForceConcentrateRecordValues.I_BFCRV_REL, 1.0);
            irl.SetValue((short)IRobotBarForceConcentrateRecordValues.I_BFCRV_X, position);
            irl.SetValue((short)IRobotBarForceConcentrateRecordValues.I_BFCRV_FZ, value);

            irl.Objects.AddOne(bar.id);
        }

        //This method generates all structure loads in the system
        public void generateStructureLoads(double concentratedLoad, double c, double e)
        {
            //check if the loads have already been created. In case they were created delete all cases
            if (loadsGenerated)
            {
                RobotSelection iAllCases = iRobotApp.Project.Structure.Selections.CreateFull(IRobotObjectType.I_OT_CASE);
                iRobotApp.Project.Structure.Cases.DeleteMany(iAllCases);
            }

            //Get reference to load cases server
            IRobotCaseServer iCases = (IRobotCaseServer)iRobotApp.Project.Structure.Cases;

            //Get first available (free) user number for load
            int caseNumber = iCases.FreeNumber;

            //Create DeadLoad case
            IRobotSimpleCase deadLoadCase = (IRobotSimpleCase)iCases.CreateSimple(caseNumber, "Peso Proprio", IRobotCaseNature.I_CN_PERMANENT, IRobotCaseAnalizeType.I_CAT_STATIC_LINEAR);

            IRobotLoadRecord2 deadLoadRecord = (IRobotLoadRecord2)deadLoadCase.Records.Create(IRobotLoadRecordType.I_LRT_DEAD);
            deadLoadRecord.SetValue((short)IRobotDeadRecordValues.I_DRV_ENTIRE_STRUCTURE, (double)1);

            //Create First lifiting load case
            IRobotSimpleCase lifitingCase1 = (IRobotSimpleCase)iCases.CreateSimple(caseNumber + 1, "Talha 1", IRobotCaseNature.I_CN_ACCIDENTAL, IRobotCaseAnalizeType.I_CAT_STATIC_LINEAR);
            //Calculate the relative position of the load
            double relativePosition1 = ((c - e) / 2) / c;
            createConcentratedLoad(lifitingCase1, relativePosition1, concentratedLoad, bars[5]);

            //Create second lifting load case
            IRobotSimpleCase liftingCase2 = (IRobotSimpleCase)iCases.CreateSimple(caseNumber + 2, "Talha 2", IRobotCaseNature.I_CN_ACCIDENTAL, IRobotCaseAnalizeType.I_CAT_STATIC_LINEAR);
            createConcentratedLoad(liftingCase2, 0.5, concentratedLoad, bars[5]);

            //Create load combinations
            IRobotCaseCombination uls1 = (IRobotCaseCombination)iCases.CreateCombination(caseNumber + 3, "ULS-1", IRobotCombinationType.I_CBT_ULS, IRobotCaseNature.I_CN_ACCIDENTAL, IRobotCaseAnalizeType.I_CAT_COMB);
            uls1.CaseFactors.New(caseNumber, (double)1.0);
            uls1.CaseFactors.New(caseNumber + 1, (double)1.0);

            IRobotCaseCombination uls2 = (IRobotCaseCombination)iCases.CreateCombination(caseNumber + 4, "ULS-2", IRobotCombinationType.I_CBT_ULS, IRobotCaseNature.I_CN_ACCIDENTAL, IRobotCaseAnalizeType.I_CAT_COMB);
            uls2.CaseFactors.New(caseNumber, (double)1.0);
            uls2.CaseFactors.New(caseNumber + 2, 1.0);

            IRobotCaseCombination sls1 = (IRobotCaseCombination)iCases.CreateCombination(caseNumber + 5, "SLS-1", IRobotCombinationType.I_CBT_SLS, IRobotCaseNature.I_CN_ACCIDENTAL, IRobotCaseAnalizeType.I_CAT_COMB);
            sls1.CaseFactors.New(caseNumber, 1.0);
            sls1.CaseFactors.New(caseNumber + 1, 1.0);

            IRobotCaseCombination sls2 = (IRobotCaseCombination)iCases.CreateCombination(caseNumber + 6, "SLS-2", IRobotCombinationType.I_CBT_SLS, IRobotCaseNature.I_CN_ACCIDENTAL, IRobotCaseAnalizeType.I_CAT_COMB);
            sls2.CaseFactors.New(caseNumber, 1.0);
            sls2.CaseFactors.New(caseNumber + 2, 1.0);

            loadsGenerated = true;
        }//createConcentratedLoad

        //This method calculates the entire struture
        public bool calculateStructure()
        {
            if (!geometryCreated && !loadsGenerated) return false;

            RobotCalcEngine calcEngine = iRobotApp.Project.CalcEngine;
            calcEngine.GenerationParams.GenerateNodes_BarsAndFiniteElems = true;
            calcEngine.UseStatusWindow = true;

            if (calcEngine.Calculate() == 1) return false;

            calcEngine = null;

            return true;
        }//calculateStructure
    }
}
