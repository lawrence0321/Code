using Service.CSV.Interface;
using Service.CSV;
using Service.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DataBase.Interface;
using Service.MES.Interface;
using Service.MES;
using Common.Enums;
using Common.DTO;
using System.IO;
using System.Threading;
using Repository.Entity;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var type = typeof(UnLoadDataLog);

            //var strsql = String.Format("INSERT {0}( ", type.Name);
            //foreach (var pro in type.GetProperties())
            //{
            //    if (pro.Name == (nameof(RectifierLog.Rowid))) continue;
            //    strsql += String.Format("{0},", pro.Name);
            //}
            //strsql = strsql.Substring(0, strsql.Length - 1);
            //strsql += ")\r\n";
            //strsql += "SELECT ";
            //foreach (var pro in type.GetProperties())
            //{
            //    if (pro.Name == (nameof(RectifierLog.Rowid))) continue;
            //    strsql += String.Format("{0},", pro.Name);
            //}
            //strsql= strsql.Substring(0, strsql.Length - 1);
            //strsql += String.Format("\r\nFROM {0};", type.Name);




            //var serivce =  Service.DataBase.DBServiceFactory.Get<IRecipeService>();


            //for (int index = 0; index <= 10; index++)
            //{
            //    for (int quantity = 1; quantity <= 4; quantity++)
            //    {
            //        var dto = new RecipeDTO()
            //        {
            //            PanelCode = String.Format("TEST{0:000}-V001{1}", index, quantity),
            //            DisplayCode = String.Format("TEST{0:000}-V001{1}", index, quantity),
            //            Quantity = quantity,
            //            PMode = "A",
            //        };
            //        foreach (var pro in dto.GetType().GetProperties())
            //        {
            //            if (pro.Name == nameof(RecipeDTO.PanelCode)) continue;
            //            if (pro.Name == nameof(RecipeDTO.DisplayCode)) continue;
            //            if (pro.Name == nameof(RecipeDTO.CreateTimeTicks)) continue;
            //            if (pro.Name == nameof(RecipeDTO.Enabeld)) continue;
            //            if (pro.Name == nameof(RecipeDTO.Quantity)) continue;
            //            if (pro.Name == nameof(RecipeDTO.PMode)) continue;
            //            if (!pro.CanWrite) continue;

            //            if (pro.PropertyType == typeof(String))
            //                pro.SetValue(dto, String.Format("{0:000}", index));
            //            else if (pro.PropertyType == typeof(Boolean))
            //                pro.SetValue(dto, true);
            //            else
            //                pro.SetValue(dto, index);
            //        }
            //        var r0_0 = serivce.Insert(dto, "root");
            //    }

            //}

            //var r1 = serivce.Gets("TEST001", PModeTypes.A, false);
            //var r2 = serivce.Gets("TEST001", PModeTypes.B, false);
            //var r3 = serivce.Gets("TEST001", PModeTypes.A, true);


            var serivce = Service.DataBase.DBServiceFactory.Get<IModbus31LogService>();

            var th = new Modbus31LogDTO()
            {
                LogTimeTicks = DateTime.Now.Ticks
            };

            for (int index = 1; index <= 10; index++)
            {
                foreach (var pro in th.GetType().GetProperties())
                {
                    if (pro.Name == "Rowid") continue;
                    if (pro.Name == "LogTimeTicks") continue;
                    if (!pro.CanWrite) continue;

                    if (pro.PropertyType == typeof(String))
                        pro.SetValue(th, String.Format("{0:00}", index));
                    else if (pro.PropertyType == typeof(Boolean))
                        pro.SetValue(th, true);
                    else
                        pro.SetValue(th, index);
                }

                var r0_0 = serivce.Insert(th);
                Console.WriteLine(String.Format("Index:{0}", index)); ;
                if (index % 20 == 0) Console.Clear();
            }

            var r1 = serivce.Get();

            var r3 = serivce.Clear();

//            var r2 = serivce.Gets(DateTime.Now.AddDays(-60).Ticks, DateTime.Now.AddDays(-29).Ticks);


            //var r2 = serivce.Gets(DateTime.Now.AddDays(-1).Ticks, DateTime.Now.AddDays(1).Ticks, 2000);

            //var r3 = serivce.Gets("1", 2000);

        }
    }

}
