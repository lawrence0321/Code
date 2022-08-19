using Common;
using Common.Enums;
using Common.Interface;
using System.Collections.Generic;

namespace Controller.Interface
{
    public delegate void ExportAction(ActResult ActResult_);

    public interface IExportController:IController
    {
        bool Enabled { get; }

        void Export<T>(ExportAction ExportAction_, string ForlderPath_, string FileName_, List<T> Logs_, LanguageTypes LanguageType_ = LanguageTypes.ZHTW) where T : IDTO;
        void Export<T>(ExportAction ExportAction_, string ForlderPath_, string FileName_, long StartTicks_, long EndTicks_, long Limit_, LanguageTypes LanguageType_ = LanguageTypes.ZHTW) where T : IDTO;
        void Export<T>(ExportAction ExportAction_, string ForlderPath_, string FileName_, string LotNo_, long Limit_, LanguageTypes LanguageType_ = LanguageTypes.ZHTW) where T : IDTO;
    }
}