using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using RobotOM;

namespace RobotAPITutorial
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting Robot application...");
            //Cria um novo objeto da aplicação Robot
            IRobotApplication robApp = new RobotApplicationClass();

            //Se a aplicaçao não estiver visivel, torna o robot visivel para permitir iteracao
            if(robApp.Visible == 0)
            {
                robApp.Interactive = 1;
                robApp.Visible = 1;
            }

            Console.WriteLine("Creating concrete project...");
            //Cria o projeto da viga de concreto
            robApp.Project.New(IRobotProjectType.I_PT_SHELL);

            Console.WriteLine("Executing project settings...");
            //Configuracao das preferencias
            RobotProjectPreferences projectPrefs = robApp.Project.Preferences;

            //Configuracoes do codigo de verificacao da estrutura de concreto
            projectPrefs.SetActiveCode(IRobotCodeType.I_CT_RC_THEORETICAL_REINF, "BAEL 91");

            //Configuracao das preferencias de malha
            RobotMeshParams meshParams = projectPrefs.MeshParams;
            meshParams.SurfaceParams.Method.Method = IRobotMeshMethodType.I_MMT_DELAUNAY;
            meshParams.SurfaceParams.Generation.Type = IRobotMeshGenerationType.I_MGT_ELEMENT_SIZE;
            meshParams.SurfaceParams.Generation.ElementSize = 0.5;
            meshParams.SurfaceParams.Delaunay.Type = IRobotMeshDelaunayType.I_MDT_DELAUNAY;

            //Geração da estrutura
            Console.WriteLine("Generating structure");
            IRobotStructure str = robApp.Project.Structure;

            Console.WriteLine("Generating nodes...");
            str.Nodes.Create(1, 0, 0, 0);
            str.Nodes.Create(2, 3, 0, 0);
            str.Nodes.Create(3, 3, 3, 0);
            str.Nodes.Create(4, 0, 3, 0);
            str.Nodes.Create(5, 0, 0, 4);
            str.Nodes.Create(6, 3, 0, 4);
            str.Nodes.Create(7, 3, 3, 4);
            str.Nodes.Create(8, 0, 3, 4);

            str.Bars.Create(1, 1, 5);
            str.Bars.Create(2, 2, 6);
            str.Bars.Create(3, 3, 7);
            str.Bars.Create(4, 4, 8);
            str.Bars.Create(5, 5, 6);
            str.Bars.Create(6, 7, 8);

            Console.WriteLine("Generating labels...");
            RobotLabelServer labels = str.Labels;

            string columnSectionName = "Rect. Column 30*30";

            IRobotLabel label = labels.Create(IRobotLabelType.I_LT_BAR_SECTION, columnSectionName);

            RobotBarSectionData section = (RobotBarSectionData)label.Data;
            section.ShapeType = IRobotBarSectionShapeType.I_BSST_CONCR_COL_R;

            RobotBarSectionConcreteData concrete = (RobotBarSectionConcreteData)section.Concrete;
            concrete.SetValue(IRobotBarSectionConcreteDataValue.I_BSCDV_COL_B, 0.3);
            concrete.SetValue(IRobotBarSectionConcreteDataValue.I_BSCDV_COL_H, 0.3);

            section.CalcNonstdGeometry();
            labels.Store(label);

            Console.WriteLine("Defining sections...");
            RobotSelection selectionBars = str.Selections.Get(IRobotObjectType.I_OT_BAR);
            selectionBars.FromText("1 2 3 4");
            str.Bars.SetLabel(selectionBars, IRobotLabelType.I_LT_BAR_SECTION, columnSectionName);

            RobotSectionDatabaseList steelSections = projectPrefs.SectionsActive;

            if(steelSections.Add("RCAT") == 1)
            {
                Console.WriteLine("Warning! Steel section base RCAT not found...");
            }

            selectionBars.FromText("5 6");
            label = labels.Create(IRobotLabelType.I_LT_BAR_SECTION, "HEA 340");
            str.Labels.Store(label);
            str.Bars.SetLabel(selectionBars, IRobotLabelType.I_LT_BAR_SECTION, "HEA 340");

            Console.WriteLine("Defining materials...");

            string materialName = "Concrete 30";

            label = labels.Create(IRobotLabelType.I_LT_MATERIAL, materialName);

            RobotMaterialData material = (RobotMaterialData)label.Data;
            material.Type = IRobotMaterialType.I_MT_CONCRETE;
            material.E = 3E+09;
            material.NU = 1 / 6;
            material.RO = 25000;
            material.Kirchoff = material.E / (2 * (1 + material.NU));

            Console.WriteLine("Generating slab...");
            RobotPointsArray points = (RobotPointsArray)robApp.CmpntFactory.Create(IRobotComponentType.I_CT_POINTS_ARRAY);
            points.SetSize(5);
            points.Set(1, 0, 0, 4);
            points.Set(2, 3, 0, 4);
            points.Set(3, 3, 3, 4);
            points.Set(4, 0, 3, 4);
            points.Set(5, 0, 0, 4);

            string slabSectionName = "Slab 30";
            label = labels.Create(IRobotLabelType.I_LT_PANEL_THICKNESS, slabSectionName);

            RobotThicknessData thickness = (RobotThicknessData)label.Data;
            thickness.MaterialName = materialName;
            thickness.ThicknessType = IRobotThicknessType.I_TT_HOMOGENEOUS;

            RobotThicknessHomoData thicknessData = (RobotThicknessHomoData)thickness.Data;
            thicknessData.ThickConst = 0.3;
            labels.Store(label);

            RobotObjObject slab;
            int objNumber = str.Objects.FreeNumber;
            str.Objects.CreateContour(objNumber, points);
            slab = (RobotObjObject)str.Objects.Get(objNumber);
            slab.Main.Attribs.Meshed = 1;
            slab.SetLabel(IRobotLabelType.I_LT_PANEL_THICKNESS, slabSectionName);
            slab.Initialize();

            Console.WriteLine("Adding hole in the slab...");

            points.Set(1, 1.1, 1.1, 4);
            points.Set(2, 2.5, 1.1, 4);

            RobotObjObject hole;
            


            Console.ReadLine();
        }
    }
}
