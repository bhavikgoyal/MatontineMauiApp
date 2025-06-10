using System;
using MatontineDigitalApp.Model;
using Refit;

namespace MatontineDigitalApp.Services
{
  public interface IMaTontineAPI
  {
    /* List Data*/

    [Post("/MaTontine2GetListData")]
    Task<ListDataDto> GetListData([Body(BodySerializationMethod.UrlEncoded)] Credentials cre);

    [Post("/MaTontineGetPartners")]
    Task<List<SimpleListItemData>> GetPartners();

    /* \List Data*/

    /* Countries Data*/

    [Get("/MaTontine2GetRegion")]
    Task<List<SimpleListItemData>> GetRegionsData(string pcountry);

    /* \Countries Data*/

    /* Profile */

    [Post("/MaTontine2ValidationLoginAndTelephone")]
    Task<ResponseStatus> ValidationLoginAndTelephone([Body(BodySerializationMethod.UrlEncoded)] Credentials cre);

    [Post("/MaTontine2GetProfileData")]
    Task<UserProfile> Login([Body(BodySerializationMethod.UrlEncoded)] Credentials cre);

    [Post("/MaTontine2GetSMSCode")]
    Task<Credentials> GetSMSCode([Body(BodySerializationMethod.UrlEncoded)] Credentials cre);

    [Post("/MaTontine2InitPasswordFromSMSCode")]
    Task<Credentials> InitPasswordFromSMSCode([Body(BodySerializationMethod.UrlEncoded)] Credentials cre);

    [Post("/MaTontineSaveProfile")]
    Task<UserProfile> SaveProfile([Body(BodySerializationMethod.UrlEncoded)] Credentials cre);

    [Post("/MaTontine2SaveProfile")]
    Task<UserProfile> UpdateProfile([Body(BodySerializationMethod.UrlEncoded)] UserProfile profile);

    [Post("/MaTontineDeleteProfile")]
    Task<UserProfile> MaTontineDeleteProfile([Body(BodySerializationMethod.UrlEncoded)] object obj);

    /* \Profile */


    /* Payment */

    [Post("/MaTontineGetListPayment")]
    Task<PaymentData[]> GetLisyPayment([Body(BodySerializationMethod.UrlEncoded)] Credentials cre);

    [Post("/MaTontineUpdatePayment")]
    Task<UpdatePaymentResponse> UpdatePayment([Body(BodySerializationMethod.UrlEncoded)] UpdatePaymentRequest cre);

    /* \Payment */


    /* Member */

    [Post("/MaTontine2SaveMember")]
    Task<MemberDto> SaveMember([Body(BodySerializationMethod.UrlEncoded)] MemberDto req);

    [Post("/MaTontineSaveMDEPOT")]
    Task<MdepotDto> SaveMDEPOT([Body(BodySerializationMethod.UrlEncoded)] MdepotDto req);

    //[Post("/MaTontineDeleteMember")]
    //Task<ResponseStatus> RemoveMember([Body(BodySerializationMethod.UrlEncoded)] RemoveMemberRequest req);

    [Post("/MaTontineGetListMembers")]
    Task<List<MemberDto>> GetMembers([Body(BodySerializationMethod.UrlEncoded)] GetListMembersRequest req);

    /*  \Member */


    /* Service actif*/

    [Post("/MaTontineSaveService")]
    Task<ServiceDto> SaveServiceActif([Body(BodySerializationMethod.UrlEncoded)] ServiceDto req);


    [Post("/MaTontine2SaveService")]
    Task<ServiceDto> UpdateService([Body(BodySerializationMethod.UrlEncoded)] UpdateServiceRequest req);

    [Post("/MaTontineGetListServices")]
    Task<List<ServiceDto>> GetServicesActif([Body(BodySerializationMethod.UrlEncoded)] Credentials req);

    /*  \Service actif*/

    /* Activation Service */

    [Post("/MaTontineSaveActivationService")]
    Task<ServiceDto> SaveActivationService([Body(BodySerializationMethod.UrlEncoded)] ServiceDto req);

    [Post("/MaTontineGetListActivationServices")]
    Task<List<ServiceDto>> GetActivationServices([Body(BodySerializationMethod.UrlEncoded)] Credentials req);

    /*  \Activation Service */


    /* Assignation */


    [Post("/MaTontine2SaveAssignation")]
    Task<AssignationServiceDto> SaveAssignation([Body(BodySerializationMethod.UrlEncoded)] AssignationServiceDto req);

    [Post("/MaTontineSaveAssignation")]
    Task<SaveAssignationRequest> SaveAssignation([Body(BodySerializationMethod.UrlEncoded)] SaveAssignationRequest req);

    [Post("/MaTontineGetListAssignation")]
    Task<List<AssignationDto>> GetAssignations([Body(BodySerializationMethod.UrlEncoded)] Credentials req);

    /*  \Assignation */


    /* Dashboard */

    [Post("/MaTontineGetListDashboard")]
    Task<List<DashboardDto>> GetDashboards([Body(BodySerializationMethod.UrlEncoded)] Credentials req);

    /*  \Dashboard */

    /* Report */

    [Post("/MaTontineGetListReport")]
    Task<List<ReportDto>> GetReports([Body(BodySerializationMethod.UrlEncoded)] Credentials req);

    /*  \Report */


    /* CommunityData */

    [Post("/MaTontineGetCommunityData")]
    Task<CommunityDto> GetCommunity([Body(BodySerializationMethod.UrlEncoded)] Credentials req);

    [Post("/MaTontineSaveCommunityData")]
    Task<CommunityDto> SaveCommunityData([Body(BodySerializationMethod.UrlEncoded)] CommunityDto req);

    [Get("/MaTontine2ValidationCommunityName")]
    Task<ResponseStatus> MaTontineValidationCommunityName(string ppartnerid, string plangue, string pcommunityname);

    /*  \CommunityData */


    /* Inscription */


    [Post("/MaTontineSaveInscription")]
    Task<CommunityDto> SaveInscription([Body(BodySerializationMethod.UrlEncoded)] CommunityDto req);

    //[Post("/MaTontine2SaveInscription")]
    //Task<CommunityInfosResponseDto> SaveInscription([Body(BodySerializationMethod.UrlEncoded)] CommunityInfosDto req);

    /* \Inscription */


    /* Translate */

    [Post("/MaTontine2GetListTraduction")]
    Task<List<SimpleListItemData>> GetTranslateData([Body(BodySerializationMethod.UrlEncoded)] Credentials req);

    /*  \Translate */

    /* Contacte */
    [Post("/MaTontineSendMail")]
    Task<ContacteDto> SendEmail([Body(BodySerializationMethod.UrlEncoded)] ContacteDto req);

    //[Get("/MaTontineGetAppVersion")]
    //Task<APPVSERSION> GetAppVersion(string app);

    /*  \Contacte */
  }
}
