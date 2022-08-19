using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using Common.Enums;
using Repository.Entity;

namespace Service.Extension
{
    public static class ExtensionEntity
    {
        public static RecipeDTO ToDTO(this Recipe Entity_)
        {
            return new RecipeDTO()
            {
                ID = Entity_.ID,
                PanelCode = Entity_.PanelCode,
                Quantity = Entity_.Quantity,
                Remarks = Entity_.Remarks,
                CreateTimeTicks = Entity_.CreateTimeTicks,
                PMode = Entity_.PMode,
                Size = Entity_.Size,
                WBArea = Entity_.WBArea,
                BArea = Entity_.BArea,
                Ni_WB_Adm2 = Entity_.Ni_WB_Adm2,
                Ni_B_Adm2 = Entity_.Ni_B_Adm2,
                Ni_PlatingTime = Entity_.Ni_PlatingTime,
                AuSt_Adm2 = Entity_.AuSt_Adm2,
                AuSt_PlatingTime = Entity_.AuSt_PlatingTime,
                Au_B_Adm2 = Entity_.Au_B_Adm2,
                Au_WB_Adm2 = Entity_.Au_WB_Adm2,
                Au_PlatingTime = Entity_.Au_PlatingTime,
                Enabeld = Entity_.Enabeld,
                EditorID =Entity_.EditorID,
                DisplayCode = Entity_.DisplayCode,
                Thickness =  Entity_.Thickness,
                SystemLog = Entity_.SystemLog
            };
        }

        public static LoadDataDTO ToDTO(this LoadData Entity_)
        {
            var dto = new LoadDataDTO
            {
                LoadSourceType = (LoadSourceTypes)Entity_.SourceTypeNo,
            };

            foreach (var property in typeof(LoadDataDTO).GetProperties())
            {
                if (typeof(LoadData).GetProperties().Where(p => p.Name == property.Name).Count() == 0) continue;
                var value = typeof(LoadData).GetProperties().Where(p => p.Name == property.Name).First().GetValue(Entity_);
                property.SetValue(dto,value);
            }

            return dto;
        }

        public static ThermostatLogDTO ToDTO(this ThermostatLog Entity_)
        {
            var dto = new ThermostatLogDTO();
            foreach (var property in typeof(ThermostatLog).GetProperties())
            {
                if (typeof(ThermostatLogDTO).GetProperty(property.Name) is null)continue;
                typeof(ThermostatLogDTO).GetProperty(property.Name).SetValue(dto, property.GetValue(Entity_));
            }
            return dto;
        }

        public static RectifierLogDTO ToDTO(this RectifierLog Entity_)
        {
            var dto = new RectifierLogDTO();
            foreach (var property in typeof(RectifierLog).GetProperties())
            {
                if (typeof(RectifierLogDTO).GetProperty(property.Name) is null) continue;
                typeof(RectifierLogDTO).GetProperty(property.Name).SetValue(dto, property.GetValue(Entity_));
            }
            return dto;
        }

        public static Modbus31LogDTO ToDTO(this Modbus31Log Entity_)
        {
            var dto = new Modbus31LogDTO();
            foreach (var property in typeof(Modbus31Log).GetProperties())
            {
                if (typeof(Modbus31LogDTO).GetProperty(property.Name) is null) continue;
                typeof(Modbus31LogDTO).GetProperty(property.Name).SetValue(dto, property.GetValue(Entity_));
            }
            return dto;
        }

        public static Modbus32LogDTO ToDTO(this Modbus32Log Entity_)
        {
            var dto = new Modbus32LogDTO();
            foreach (var property in typeof(Modbus32Log).GetProperties())
            {
                if (typeof(Modbus32LogDTO).GetProperty(property.Name) is null) continue;
                typeof(Modbus32LogDTO).GetProperty(property.Name).SetValue(dto, property.GetValue(Entity_));
            }
            return dto;
        }

        public static Modbus33LogDTO ToDTO(this Modbus33Log Entity_)
        {
            var dto = new Modbus33LogDTO();
            foreach (var property in typeof(Modbus33Log).GetProperties())
            {
                if (typeof(Modbus33LogDTO).GetProperty(property.Name) is null) continue;
                typeof(Modbus33LogDTO).GetProperty(property.Name).SetValue(dto, property.GetValue(Entity_));
            }
            return dto;
        }

        public static WashDeviceLogDTO ToDTO(this WashDeviceLog Entity_)
        {
            var dto = new WashDeviceLogDTO();
            foreach (var property in typeof(WashDeviceLog).GetProperties())
            {
                if (typeof(WashDeviceLogDTO).GetProperty(property.Name) is null) continue;
                typeof(WashDeviceLogDTO).GetProperty(property.Name).SetValue(dto, property.GetValue(Entity_));
            }
            return dto;
        }

    }
}
