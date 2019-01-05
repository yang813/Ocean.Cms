/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：后台管理菜单                                                    
*│　作    者：yangjb                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2018-12-22 15:58:56                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Ocean.Cms.IRepository                                   
*│　接口名称： IMenuRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using Ocean.Cms.Core.Repository;
using Ocean.Cms.Models;
using System;

namespace Ocean.Cms.IRepository
{
    public interface IMenuRepository : IBaseRepository<Menu, Int32>
    {
    }
}