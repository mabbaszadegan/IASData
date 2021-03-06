//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attachment
    {
        public int AttachmentId { get; set; }
        public string AttachmentDesc { get; set; }
        public string AttachmentFileName { get; set; }
        public string AttachmentExtention { get; set; }
        public byte[] AttachmentContent { get; set; }
        public string AttachmentContentType { get; set; }
        public System.DateTime AttachmentTime { get; set; }
        public string AttachmentTimeSolar { get; set; }
        public bool AttachmentIsDefault { get; set; }
        public Nullable<double> AttachmentLatitudeDevice { get; set; }
        public Nullable<double> AttachmentLongitudeDevice { get; set; }
        public int AttachmentTypeId { get; set; }
        public long AttachmentOwnerId { get; set; }
        public string AttachmentZiped { get; set; }
        public Nullable<int> RoleId { get; set; }
        public int UserId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual AttachmentType AttachmentType { get; set; }
    }
}
