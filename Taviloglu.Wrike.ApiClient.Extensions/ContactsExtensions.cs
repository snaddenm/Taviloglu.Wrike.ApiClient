﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.ApiClient.Extensions
{
    public static class ContactsExtensions
    {
        /// <summary>
        /// Retrieves the contacts having given type.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<WrikeUser>> GetContactsByTypeAsync(this IWrikeContactsClient wrikeContactsClient,
            WrikeUserType type,
            bool? me = null,
            WrikeMetadata metadata = null,
            bool? isDeleted = null,
            bool? retrieveMetadata = null)
        {
            var contacts = await wrikeContactsClient.GetAsync(me, metadata, isDeleted, retrieveMetadata).ConfigureAwait(false);
            return contacts.Where(c => c.Type == type).ToList();
        }

        /// <summary>
        /// Retrieves the first contact record having type person and provided email.
        /// </summary>
        public static async Task<WrikeUser> GetContactByEmailAsync(this IWrikeContactsClient wrikeContactsClient,
            string email)
        {

            if (email==null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            if (email.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(email));
            }

            var contacts = await wrikeContactsClient.GetAsync().ConfigureAwait(false);
            return contacts.Where(c =>
            c.Type == WrikeUserType.Person &&
            c.Profiles.Any(p => p.Email == email)).FirstOrDefault();
        }
    }
}
