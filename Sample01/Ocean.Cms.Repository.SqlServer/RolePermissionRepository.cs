/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：角色权限表接口实现                                                    
*│　作    者：yangjb                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2018-12-22 15:58:56                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Ocean.Cms.Repository.SqlServer                                  
*│　类    名： RolePermissionRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using Ocean.Cms.Core.DbHelper;
using Ocean.Cms.Core.Options;
using Ocean.Cms.Core.Repository;
using Ocean.Cms.IRepository;
using Ocean.Cms.Models;
using Microsoft.Extensions.Options;
using System;

namespace Ocean.Cms.Repository.SqlServer
{
    public class RolePermissionRepository:BaseRepository<RolePermission,Int32>, IRolePermissionRepository
    {
        public RolePermissionRepository(IOptionsSnapshot<DbOpion> options)
        {
            _dbOpion =options.Get("OceanCms");
            if (_dbOpion == null)
            {
                throw new ArgumentNullException(nameof(DbOpion));
            }
            _dbConnection = ConnectionFactory.CreateConnection(_dbOpion.DbType, _dbOpion.ConnectionString);
        }

    }
}