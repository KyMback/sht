using System.Threading.Tasks;
using AutoMapper;
using SHT.Domain.Models.Users;
using SHT.Domain.Users.Accounts;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Users.Students
{
    internal class StudentAccountService : IStudentAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAccountService _userAccountService;
        private readonly IMapper _mapper;
        private readonly IRegistrationValidationService _registrationValidationService;

        public StudentAccountService(
            IUnitOfWork unitOfWork,
            IUserAccountService userAccountService,
            IMapper mapper,
            IRegistrationValidationService registrationValidationService)
        {
            _unitOfWork = unitOfWork;
            _userAccountService = userAccountService;
            _mapper = mapper;
            _registrationValidationService = registrationValidationService;
        }

        public async Task<Student> Create(StudentCreationData data)
        {
            await _registrationValidationService.TrowsIfEmailIsNotUniq(data.Email);
            var account = await _userAccountService.Create(_mapper.Map<AccountCreationData>(data));
            var student = await _unitOfWork.Add(new Student
            {
                Account = account,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Group = data.Group,
            });
            await _unitOfWork.Commit();
            await _userAccountService.SendEmailConfirmation(account);

            return student;
        }
    }
}