using Common.Interface;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataBase
{
    internal static class IDFactory
    {
        readonly static object Token = new object();
        public static string GetNewIDAndTimeTick(this IEntity Obj_)
        {
            lock (Token)
            {
                string guid = Guid.NewGuid().ToString().Replace("-", "");
                long tick = DateTime.Now.Ticks;

                switch (Obj_)
                {
                    case Recipe recipe:
                        recipe.ID = String.Format("{0:00}{1}", 01, guid);
                        recipe.CreateTimeTicks = tick;
                        recipe.Enabeld = true;
                        return recipe.ID;
                    case LoadData loadData:
                        loadData.ID = String.Format("{0:00}{1}", 02, guid);
                        loadData.CreateTimeTicks = tick;
                        loadData.SortTimeTicks = tick;
                        loadData.FinishTimeTicks = 0;
                        loadData.Enabled = true;
                        return loadData.ID;


                    default:
                        throw new Exception("Not Support This Class.");
                }


            }
        }

    }
}
