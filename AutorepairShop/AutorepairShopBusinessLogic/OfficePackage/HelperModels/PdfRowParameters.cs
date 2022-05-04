using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorepairShopBusinessLogic.OfficePackage.HelperEnums;


namespace AutorepairShopBusinessLogic.OfficePackage.HelperModels
{
    public class PdfRowParameters
    {

        public List<string> Texts { get; set; }
        public string Style { get; set; }
        public PdfParagraphAlignmentType ParagraphAlignment { get; set; }

    }
}
