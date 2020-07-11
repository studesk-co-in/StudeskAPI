using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudeskDAL
{
    /// <summary>
    /// Author : Yogesh Wani  
    /// Date   : 07-July-2020
    /// Reason For Change : Initial Setup 
    /// Description : All institute related classes.
    /// </summary>
    public class InstituteData // Only Properties are included
    {
        public InstituteData()
        {

        }
        public Guid InstituteId { get; set; }
        public string InstituteName { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int District { get; set; }
        public int Tehsil { get; set; }
        public int Area { get; set; }
        public string Pincode { get; set; }
        public int TypeOfInstitute { get; set; }
        public int GovernBy { get; set; }
        public string InstituteLogo { get; set; }
        public int IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string RHID { get; set; }

    }
    public class CommunicationDetailsData
    {
        public CommunicationDetailsData()
        {

        }
        public Guid CD_ID { get; set; }
        public Guid InstituteId { get; set; }
        public int ContactType { get; set; }
        public string ContactInfo { get; set; }
        public int IsActive { get; set; }
        public DateTime CreateDate { get; set; }

    }
    public class ClassMasterData
    {
        public ClassMasterData()
        {

        }
        public Guid ICM_ID { get; set; }
        public Guid InstituteId { get; set; }
        public Guid ClassId { get; set; }
        public int RecognizedBy { get; set; }
        public string InstituteCourseId { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int IsActive { get; set; }

    }
    public class FormsDownloadData
    {
        public FormsDownloadData()
        {

        }
        public Guid IFD_ID { get; set; }
        public Guid InstituteId { get; set; }
        public int AccessType { get; set; }
        public string FormName { get; set; }
        public DateTime ValidTill { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int IsActive { get; set; }

    }
    public class AdditionalInfoData
    {
        public AdditionalInfoData()
        {

        }
        public int IAI_ID { get; set; }
        public Guid InstituteId { get; set; }
        public int InformationType { get; set; }
        public string InformationDetails { get; set; }
        public int IsActive { get; set; }
        public DateTime CreateDate { get; set; }

    }
    public class NoticeBoardData
    {
        public NoticeBoardData()
        {

        }
        public Guid NB_ID { get; set; }
        public Guid InstituteId { get; set; }
        public int NoticeType { get; set; }
        public string NoticeDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime NoticeReleaseDate { get; set; }
        public int IsActive { get; set; }
        public Guid CreatedBy { get; set; }

    }     
    public class ReferenceHeirarchyData
    {
        public ReferenceHeirarchyData()
        {

        }
        public Guid RHID { get; set; }
        public Guid ReferredBy { get; set; }
        public string InstituteName { get; set; }
        public string Location { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
