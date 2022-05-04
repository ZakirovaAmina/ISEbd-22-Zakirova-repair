using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorepairShopBusinessLogic.OfficePackage.HelperEnums;
using AutorepairShopBusinessLogic.OfficePackage.HelperModels;

namespace AutorepairShopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties {
                    Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            foreach (var repair in info.Repairs)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> {
                       (repair.RepairName + ": ", new WordTextProperties {
                        Size = "24",
                        Bold = true
                        }),
                        (Convert.ToInt32(repair.Price).ToString(), new WordTextProperties {
                        Size = "24"
                        })
                    },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }
            SaveWord(info);
        }

        // Создание doc-файла
        protected abstract void CreateWord(WordInfo info);
        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);
        // Сохранение файла
        protected abstract void SaveWord(WordInfo info);
    }
}
