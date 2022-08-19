using Common.DTO;
using Repository.Entity;
using System.Linq;

namespace Service.Extension
{
    public static class ExtensionDTO
    {
        public static Recipe ToEntity(this RecipeDTO DTO_)
        {
            var entity = new Recipe
            {
                ID = DTO_.ID,
                PanelCode = DTO_.PanelCode,
                Quantity = DTO_.Quantity,

                Remarks = DTO_.Remarks,

                PMode = DTO_.PMode,
                Size = DTO_.Size,
                WBArea = DTO_.WBArea,
                BArea = DTO_.BArea,
                Ni_WB_Adm2 = DTO_.Ni_WB_Adm2,
                Ni_B_Adm2 = DTO_.Ni_B_Adm2,
                Ni_PlatingTime = DTO_.Ni_PlatingTime,
                AuSt_Adm2 = DTO_.AuSt_Adm2,
                AuSt_PlatingTime = DTO_.AuSt_PlatingTime,
                Au_B_Adm2 = DTO_.Au_B_Adm2,
                Au_WB_Adm2 = DTO_.Au_WB_Adm2,
                Au_PlatingTime = DTO_.Au_PlatingTime
            };

            return entity;
        }

        public static Recipe ToEntity(this RecipeDTO DTO_, Recipe Entity_ = null)
        {
            var entity = Entity_;

            entity.Remarks = DTO_.Remarks;

            entity.PMode = DTO_.PMode;
            entity.Size = DTO_.Size;
            entity.WBArea = DTO_.WBArea;
            entity.BArea = DTO_.BArea;
            entity.Ni_WB_Adm2 = DTO_.Ni_WB_Adm2;
            entity.Ni_B_Adm2 = DTO_.Ni_B_Adm2;
            entity.Ni_PlatingTime = DTO_.Ni_PlatingTime;
            entity.AuSt_Adm2 = DTO_.AuSt_Adm2;
            entity.AuSt_PlatingTime = DTO_.AuSt_PlatingTime;
            entity.Au_B_Adm2 = DTO_.Au_B_Adm2;
            entity.Au_WB_Adm2 = DTO_.Au_WB_Adm2;
            entity.Au_PlatingTime = DTO_.Au_PlatingTime;

            return entity;
        }

        public static ThermostatLog ToEntity(this ThermostatLogDTO DTO_)
        {
            var entity = new ThermostatLog();

            foreach (var property in typeof(ThermostatLog).GetProperties())
            {
                if (typeof(ThermostatLogDTO).GetProperty(property.Name) == null) continue;
                if (property.Name == nameof(ThermostatLogDTO.Rowid)) continue;
                if (property.Name == nameof(ThermostatLogDTO.LogTimeTicks)) continue;

                var value = typeof(ThermostatLogDTO).GetProperty(property.Name).GetValue(DTO_);
                property.SetValue(entity, value);
            }

            return entity;
        }

        public static RectifierLog ToEntity(this RectifierLogDTO DTO_)
        {
            var entity = new RectifierLog()
            {
                LogTimeTicks = DTO_.LogTimeTicks,
            };

            foreach (var property in typeof(RectifierLog).GetProperties())
            {
                if (typeof(RectifierLogDTO).GetProperties().Where(p => p.Name == property.Name).Count() == 0) continue;

                var value = typeof(RectifierLogDTO).GetProperties().Where(p => p.Name == property.Name).FirstOrDefault().GetValue(DTO_);
                property.SetValue(entity, value);
            }

            return entity;
        }

        public static WashDeviceLog ToEntity(this WashDeviceLogDTO DTO_)
        {
            var entity = new WashDeviceLog()
            {
                LogTimeTicks = DTO_.LogTimeTicks,
                Speed = DTO_.Speed,
                Temperature = DTO_.Temperature
            };

            return entity;
        }

        public static LoadData ToEntity(this LoadDataDTO DTO_)
        {
            var entity = new LoadData()
            {
                SourceTypeNo = (int)DTO_.LoadSourceType,
            };

            foreach (var property in typeof(LoadData).GetProperties())
            {
                if (typeof(LoadDataDTO).GetProperties().Where(p => p.Name == property.Name).Count() == 0) continue;
                var value = typeof(LoadDataDTO).GetProperties().Where(p => p.Name == property.Name).FirstOrDefault().GetValue(DTO_);
                property.SetValue(entity, value);
            }
            return entity;
        }

        public static LoadData ToEntity(this LoadDataDTO DTO_, LoadData Entity_)
        {
            foreach (var property in typeof(LoadData).GetProperties())
            {
                if (typeof(LoadDataDTO).GetProperties().Where(p => p.Name == property.Name).Count() == 0) continue;
                var value = typeof(LoadDataDTO).GetProperties().Where(p => p.Name == property.Name).FirstOrDefault().GetValue(DTO_);
                property.SetValue(Entity_, value);
            }
            return Entity_;
        }


        public static UnLoadDataLog ToEntity(this UnLoadDataLogDTO DTO_)
        {
            var entity = new UnLoadDataLog();

            foreach (var property in typeof(UnLoadDataLog).GetProperties())
            {
                if (typeof(UnLoadDataLogDTO).GetProperties().Where(p => p.Name == property.Name).Count() == 0) continue;
                var value = typeof(UnLoadDataLogDTO).GetProperties().Where(p => p.Name == property.Name).FirstOrDefault().GetValue(DTO_);
                property.SetValue(entity, value);
            }
            return entity;
        }

        public static Modbus31Log ToEntity(this Modbus31LogDTO DTO_)
        {
            var entity = new Modbus31Log()
            {
                LogTimeTicks = DTO_.LogTimeTicks,
            };

            foreach (var property in typeof(Modbus31Log).GetProperties())
            {
                if (typeof(Modbus31LogDTO).GetProperty(property.Name) is null) continue;

                var value = typeof(Modbus31LogDTO).GetProperty(property.Name).GetValue(DTO_);
                property.SetValue(entity, value);
            }
            return entity;
        }

        public static Modbus32Log ToEntity(this Modbus32LogDTO DTO_)
        {
            var entity = new Modbus32Log()
            {
                LogTimeTicks = DTO_.LogTimeTicks,
            };

            foreach (var property in typeof(Modbus32Log).GetProperties())
            {
                if (typeof(Modbus32LogDTO).GetProperty(property.Name) is null) continue;

                var value = typeof(Modbus32LogDTO).GetProperty(property.Name).GetValue(DTO_);
                property.SetValue(entity, value);
            }
            return entity;
        }

        public static Modbus33Log ToEntity(this Modbus33LogDTO DTO_)
        {
            var entity = new Modbus33Log()
            {
                LogTimeTicks = DTO_.LogTimeTicks,
            };

            foreach (var property in typeof(Modbus33Log).GetProperties())
            {
                if (typeof(Modbus33LogDTO).GetProperty(property.Name) is null) continue;

                var value = typeof(Modbus33LogDTO).GetProperty(property.Name).GetValue(DTO_);
                property.SetValue(entity, value);
            }
            return entity;
        }


    }
}
