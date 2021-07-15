using System;
using System.Collections.Generic;
using System.DirectoryServices;

namespace CrmDiagTool2011.Helpers
{
    /// <summary>
    /// This class is used to retrieve data from Active Directory
    /// </summary>
    class ADHelper
    {
        /// <summary>
        /// This returns DirectoryEntry object.
        /// If the function parameter is null, we will get 
        /// the default root directory entry of the current context.
        /// </summary>
        /// <param name="StrMyGUID">
        /// The AD GUID as a string in order to perform a direct GUID Bin, 
        /// if null then it will return the DirectoryEntry maching the defaultNamingContext
        /// </param>
        public static DirectoryEntry GetDirectoryEntry(string strMyGUID)
        {
            try
            {
                if (strMyGUID != null)
                {
                    return new DirectoryEntry("LDAP://<GUID=" + strMyGUID + ">");
                }
                else
                {
                    string defaultContext = string.Empty;
                        
                    using (DirectoryEntry myDE = new DirectoryEntry("LDAP://RootDSE"))
                    {
                        defaultContext = myDE.Properties["defaultNamingContext"].Value.ToString();
                    }
                    
                    return new DirectoryEntry("LDAP://" + defaultContext);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Return a specified AD property collection for a given Active Directory Objet
        /// Can be the membership collection of a given active directory Group
        /// or a single property like Distiguished Name of a Group.
        /// </summary>
        /// <param name="strGroupADGUID">The Active Directory GUID of the Active Directory Object</param>
        /// <param name="strAdProperty">The property to retrieved like [member],[distinguishedName],[sAMAccountName],etc...</param>
        /// <returns></returns>
        public static Dictionary<string, string> ActiveDirectoryProperty(string strGroupADGUID, string strAdProperty)
        {
            Dictionary<string, string> ActiveDirectoryPropertyList = new Dictionary<string, string>();

            try
            {
                // Retrieve all properties of the specified AD Object
                PropertyCollection prop = GetDirectoryEntry(strGroupADGUID).Properties;
                // Get the Count of property objects
                int count = prop[strAdProperty].Count;

                // Test if the property is a singleton object or array of objects.
                if (count == 1) // That's a singleton so the Collection will have only one member.
                {
                    ActiveDirectoryPropertyList.Add(strAdProperty, prop[strAdProperty].Value.ToString());
                    return ActiveDirectoryPropertyList;
                }
                else // That's not a singleton we will fill the collection
                {
                    // create a simple counter to differentiate the added Key
                    int i = 1;
                    
                    // Create an Object array matching the size define above
                    object[] oObjectCollection = new object[count];
                    
                    // Copy the group items into the Object Array
                    prop[strAdProperty].CopyTo(oObjectCollection, 0);
                    
                    // Define a string array matching the size of the object array.
                    string[] strArrProperties = new string[oObjectCollection.Length];
                    
                    // Copy the Object Array -> String Array
                    oObjectCollection.CopyTo(strArrProperties, 0);

                    // Loop into this array and fill the collection
                    foreach (string member in strArrProperties)
                    {
                        if (!String.IsNullOrEmpty(member))
                        {
                            ActiveDirectoryPropertyList.Add(strAdProperty + i, member);
                            i++;
                        }
                    }

                    return ActiveDirectoryPropertyList;
                }
            }
            catch (Exception e)
            {
                ActiveDirectoryPropertyList.Add(strAdProperty, String.Format("Error:{0}", e.Message));
                return ActiveDirectoryPropertyList;
            }
        }
    }
}
