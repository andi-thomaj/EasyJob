using System.Collections.Generic;

namespace EasyJob.Application.Contracts.Identity
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(ControllerName controller)
        {
            return new List<string>()
            {
                $"Permissions.{controller}.Create",
                $"Permissions.{controller}.View",
                $"Permissions.{controller}.Edit",
                $"Permissions.{controller}.Delete",
            };
        }

        public static string GetPermission(ControllerName controller, Crud crud)
        {
            return $"Permissions.{controller}.{crud}";
        }
    }
    public enum ControllerName
    {
        Posts,
        Accounts
    }

    public enum Crud
    {
        Create,
        View,
        Edit,
        Delete
    }
}