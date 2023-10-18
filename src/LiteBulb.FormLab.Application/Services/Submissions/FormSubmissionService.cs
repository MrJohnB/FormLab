using LiteBulb.FormLab.Domain.Dtos.Submissions;
using LiteBulb.FormLab.Shared.Repositories;
using LiteBulb.FormLab.Shared.Services.Data;
using Microsoft.Extensions.Logging;

namespace LiteBulb.FormLab.Application.Services.Submissions;
public class FormSubmissionService : Service<FormSubmission, int>
{
    public FormSubmissionService(ILogger<FormSubmissionService> logger, IRepository<FormSubmission, int> formSubmissionRepository)
        : base(logger, formSubmissionRepository) { }
}
