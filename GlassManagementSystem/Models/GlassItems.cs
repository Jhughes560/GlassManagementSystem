using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlassManagementSystem.Models
{
    public class GlassItems
    {

        //Universal Fields

        [Key]
        public int ID { get; set; }

        public int GlassID { get; set; }

        public string GlassType { get; set; }

        public int GlassHeight { get; set; }

        public int GlassWidth { get; set; }

        public string Comments { get; set; }

        //Double Glazing

        public string OuterGlassThickness { get; set; }

        public string OuterGlassBuild { get; set; }

        public int SpacerBarSize { get; set; }

        public string FlapHole { get; set; }

        public string SpacerBarColour { get; set; }

        public string InnerGlassThickness { get; set; }

        public string InnerGlassBuild { get; set; }

        //Single Glazing

        public string SingleGlassThickness { get; set; }

        public string SingleGlassBuild { get; set; }

        //Mirror
        public string MirrorThickness { get; set; }

        public string SafetyBacked { get; set; }

        public string PolishedEdges { get; set; }
    }
}
