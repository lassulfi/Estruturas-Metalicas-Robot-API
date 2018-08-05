using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotOM;

namespace MonoviaRobot.model
{
    class Material
    {

        //Atributes
        string name { get; set; }
        double elasticity { get; set; }
        double poisson { get; set; }
        double specificWeight { get; set; }
        double kirchoff { set;  get; }
        
        //Constructor
        public Material(string name, double elasticity, double poisson, double wheight, IRobotMaterialType materialType)
        {
            this.name = name;
            this.elasticity = elasticity;
            this.poisson = poisson;
            this.specificWeight = wheight;
            calculateKirchoff();
        }

        //Methods
        private void calculateKirchoff()
        {
            kirchoff = elasticity / (2 * (1 + poisson));
        }

        public void assignToModel(IRobotMaterialType materialType)
        {
            IRobotLabel label = RobotLabels.createLabel(IRobotLabelType.I_LT_MATERIAL, name);
            RobotMaterialData material = (RobotMaterialData)label.Data;
            material.Type = materialType;
            material.E = elasticity;
            material.NU = poisson;
            material.RO = specificWeight;
            material.Kirchoff = kirchoff;
        }

    }
}
