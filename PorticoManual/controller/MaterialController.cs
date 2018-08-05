using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PorticoManual.model;
using RobotOM;

namespace PorticoManual.controller
{
    class MaterialController
    {
        //Atributos
        private MaterialController instance = new MaterialController();

        private Structure structure;

        public Material material { get; set; }
        public List<Material> materials { get; set; }

        //Construtor
        private MaterialController()
        {
            //Creates a new list o materials
            materials = new List<Material>();

            //get the instance of the structure
            structure = Structure.getInstance();
        }

        //Métodos
        //This method returns the instance og the 
        public MaterialController getInstance()
        {
            return instance;
        }

        //create a material instance and add to 
        public void create(string name, double elasticity, double poisson, double weigth, IRobotMaterialType robotMaterialType)
        {
            material = new Material(name, elasticity, poisson, weigth, robotMaterialType);
            materials.Add(material);

            //Adding the material to the current project
            //Acessing RobotLabelServer
            IRobotLabel materialLabel = structure.getLabelServer().Create(IRobotLabelType.I_LT_MATERIAL, name);
            //Accessing data properties
            RobotMaterialData materialData = (RobotMaterialData)materialLabel.Data;
            materialData.Type = robotMaterialType;
            materialData.E = elasticity;
            materialData.NU = poisson;
            materialData.RO = weigth;
            materialData.Kirchoff = material.kirchoff;

            structure.getLabelServer().Store(materialLabel);
                            
        }//create

        public void update(int pos, double elasticity, double poisson, double weigth, IRobotMaterialType robotMaterialType)
        {

        }
    }
}
