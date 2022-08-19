using Repository.Interface;
using Common.Extension;
using Common.Enums;
using System;

namespace Repository.Implement
{
    internal static class BasicData
    {
        public static void Seed(IDBContext DBContext_)
        {
            try
            {
                foreach (AlarmTypes_Part01 alarm in Enum.GetValues(typeof(AlarmTypes_Part01)))
                {
                    if (alarm.GetInfo() is null) continue;
                    if (!alarm.GetInfo().Enabled) continue;
                    if (alarm == AlarmTypes_Part01.None) continue;
                    DBContext_.Alarms.Add(new Entity.Alarm()
                    {
                        No = alarm.GetInfo().No,
                        Name = alarm.GetDisplay().ENG,
                        ChiName = alarm.GetDisplay().ZHTW,
                    });
                }
                foreach (AlarmTypes_Part02 alarm in Enum.GetValues(typeof(AlarmTypes_Part02)))
                {
                    if (alarm.GetInfo() is null) continue;
                    if (!alarm.GetInfo().Enabled) continue;
                    if (alarm == AlarmTypes_Part02.None) continue;
                    DBContext_.Alarms.Add(new Entity.Alarm()
                    {
                        No = alarm.GetInfo().No,
                        Name = alarm.GetDisplay().ENG,
                        ChiName = alarm.GetDisplay().ZHTW,
                    });
                }
                foreach (AlarmTypes_Part03 alarm in Enum.GetValues(typeof(AlarmTypes_Part03)))
                {
                    if (alarm.GetInfo() is null) continue;
                    if (!alarm.GetInfo().Enabled) continue;
                    if (alarm == AlarmTypes_Part03.None) continue;
                    DBContext_.Alarms.Add(new Entity.Alarm()
                    {
                        No = alarm.GetInfo().No,
                        Name = alarm.GetDisplay().ENG,
                        ChiName = alarm.GetDisplay().ZHTW,
                    });
                }
                foreach (AlarmTypes_Part04 alarm in Enum.GetValues(typeof(AlarmTypes_Part04)))
                {
                    if (alarm.GetInfo() is null) continue;
                    if (!alarm.GetInfo().Enabled) continue;
                    if (alarm == AlarmTypes_Part04.None) continue;
                    DBContext_.Alarms.Add(new Entity.Alarm()
                    {
                        No = alarm.GetInfo().No,
                        Name = alarm.GetDisplay().ENG,
                        ChiName = alarm.GetDisplay().ZHTW,
                    });
                }
                foreach (AlarmTypes_Part05 alarm in Enum.GetValues(typeof(AlarmTypes_Part05)))
                {
                    if (alarm.GetInfo() is null) continue;
                    if (!alarm.GetInfo().Enabled) continue;
                    if (alarm == AlarmTypes_Part05.None) continue;
                    DBContext_.Alarms.Add(new Entity.Alarm()
                    {
                        No = alarm.GetInfo().No,
                        Name = alarm.GetDisplay().ENG,
                        ChiName = alarm.GetDisplay().ZHTW,
                    });
                }
                foreach (AlarmTypes_Part06 alarm in Enum.GetValues(typeof(AlarmTypes_Part06)))
                {
                    if (alarm.GetInfo() is null) continue;
                    if (!alarm.GetInfo().Enabled) continue;
                    if (alarm == AlarmTypes_Part06.None) continue;
                    DBContext_.Alarms.Add(new Entity.Alarm()
                    {
                        No = alarm.GetInfo().No,
                        Name = alarm.GetDisplay().ENG,
                        ChiName = alarm.GetDisplay().ZHTW,
                    });
                }
                foreach (AlarmTypes_Part07 alarm in Enum.GetValues(typeof(AlarmTypes_Part07)))
                {
                    if (alarm.GetInfo() is null) continue;
                    if (!alarm.GetInfo().Enabled) continue;
                    if (alarm == AlarmTypes_Part07.None) continue;
                    DBContext_.Alarms.Add(new Entity.Alarm()
                    {
                        No = alarm.GetInfo().No,
                        Name = alarm.GetDisplay().ENG,
                        ChiName = alarm.GetDisplay().ZHTW,
                    });
                }
                foreach (AlarmTypes_Part08 alarm in Enum.GetValues(typeof(AlarmTypes_Part08)))
                {
                    if (alarm.GetInfo() is null) continue;
                    if (!alarm.GetInfo().Enabled) continue;
                    if (alarm == AlarmTypes_Part08.None) continue;
                    DBContext_.Alarms.Add(new Entity.Alarm()
                    {
                        No = alarm.GetInfo().No,
                        Name = alarm.GetDisplay().ENG,
                        ChiName = alarm.GetDisplay().ZHTW,
                    });
                }

            }
            catch
            { 
            
            }
        }
    }

}
