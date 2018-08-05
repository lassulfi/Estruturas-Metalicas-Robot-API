using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotOM;

namespace PorticoManual.model
{
    class Material
    {
        //Atributos
        public string name { get; set; }
        public double elasticity { get; set; }
        public double poisson { get; set; }
        public double specificWeigth { get; set; }
        public IRobotMaterialType iRobotMaterialType { get; set; }
        public double kirchoff { get; set; }

        //Construtor
        public Material(string name, double elasticity, double poisson, double weigth, IRobotMaterialType robotMaterialType)
        {
            this.name = name;
            this.elasticity = elasticity;
            this.poisson = poisson;
            this.specificWeigth = weigth;
            this.kirchoff = calculateKirchoff(elasticity, poisson);
            this.iRobotMaterialType = robotMaterialType;
        }

        public double calculateKirchoff(double elasticity, double poisson)
        {
            return elasticity / (2 * (1 + poisson));
        }

        public override string ToString()
        {
            return "Material name: " + name
                    + ",modulus of elasticity: " + elasticity
                    + ", poisson coefficient: " + poisson
                    + ", Specific weight: " + specificWeigth
                    + ", Kirchoff modulus: " + kirchoff
                    + ", Robot Material type: " + iRobotMaterialType;
        }
    }
}
