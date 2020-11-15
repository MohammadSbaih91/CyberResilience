using CyberResilience.Common.DTOs.Admin.ToolkitDTO;
using CyberResilience.Common.Utilities;
using CyberResilience.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.BLL.AdminBLL.ToolkitsBusinessLogic
{
    public class ToolkitsBusinessLogic
    {
        public bool AddToolkit(ToolkitDTO dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var isAdded = uow.Toolkit.AddToolkit(dto);
                    if (isAdded == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("AddToolkit", "An error occurred while trying to create Toolkit Record - BLL");
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public ToolkitDTO GetToolkit(int toolkitId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var toolkit = uow.Toolkit.GetToolkit(toolkitId);
                    if (toolkit != null)
                    {
                        return toolkit;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetToolkit", "An error occurred while trying to Get Toolkit Record - BLL");
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public List<ToolkitDTO> GetToolkitsByType(int toolkitType)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var toolkits = uow.Toolkit.GetToolkitsByType(toolkitType);
                    if (toolkits != null)
                    {
                        return toolkits;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetToolkitsByType", "An error occurred while trying to get Toolkits Record - BLL");
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public List<ToolkitDTO> GetAllToolkits()
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var toolkits = uow.Toolkit.GetAllToolkits();
                    if (toolkits != null)
                    {
                        return toolkits;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetAllToolkits", "An error occurred while trying to get all Toolkits Record - BLL");
                    Tracer.Error(ex);
                    return null;
                }
            }
        }

        public bool DeleteToolkit(int ToolkitId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var toolkits = uow.Toolkit.DeleteToolkit(ToolkitId);
                    if (toolkits != null)
                    {
                        return toolkits;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("DeleteToolkit", "An error occurred while trying to DeleteToolkit Record - BLL");
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        
    }
}
