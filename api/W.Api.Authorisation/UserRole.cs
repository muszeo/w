//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       UserRole.cs
//  Desciption: MyTrucking User Role Enumeration
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
#endregion

namespace W.Api.Authorisation
{
    /// <summary>
    /// User Roles.
    /// NB. These are additive.
    /// +--------+----------+-----------------+-----------+
    /// | RoleID | UserRole | RoleDescription | RoleLevel |
    /// +--------+----------+-----------------+-----------+
    /// |      1 | Admin    | System          |        10 |
    /// |      2 | Owner    | Super User      |        20 |
    /// |      3 | Operator | Operator        |        40 |
    /// |      4 | Driver   | Driver          |        50 |
    /// |      5 | Finance  | Full Access     |        30 |
    /// |      6 | Operator | Basic Operator  |        41 |
    /// +--------+----------+-----------------+-----------+
    /// </summary>
    public enum UserRole
    {
        [RoleLevel (10)]
        Admin = 1,

        [RoleLevel (20)]
        Owner = 2,

        [RoleLevel (40)]
        Operator = 3,

        [RoleLevel (50)]
        Driver = 4,

        [RoleLevel (30)]
        Finance = 5,

        [RoleLevel (41)]
        BasicOperator = 6
    }

    /// <summary>
    /// RoleLevel Attribute for UserRoles enumeration.
    /// </summary>
    [AttributeUsage (AttributeTargets.Field)]
    public class RoleLevel : Attribute
    {
        public int Level { get; private set; }

        public RoleLevel (int level)
        {
            Level = level;
        }
    }
}