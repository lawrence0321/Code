using Common;
using Common.DTO;
using Common.Interface;
using System.Collections.Generic;

namespace Service.DataBase.Interface
{
    public interface ILoadDataService : IService
    {
        ActResult<LoadDataDTO> Get(string LoadDataID_);

        ActResult<LoadDataDTO> Edit(LoadDataDTO DTO_, string EditorID_);

        ActResult Finish(string ID_);

        ActResult Insert(List<LoadDataDTO> DTO_, string EditorID_);

        ActResult PlugIn(List<LoadDataDTO> DTO_, long AfterSortTimeTicks_, string EditorID_);

        ActResult ReMove(string ID_, string EditorID_);

        ActResult ReSetQueue(string EditorID_);

        ActResult<List<LoadDataDTO>> GetAllUnFinish();

        ActResult<LoadDataDTO> GetUnFinishFirst();
        ActResult<List<LoadDataDTO>> Gets(long startTimeTicks_, long endTimeTicks_, long limit_);
    }


}
