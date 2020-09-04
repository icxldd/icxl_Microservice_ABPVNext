﻿using BaseService.BaseData.EmployeeManagement.Dto;
using BaseService.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace BaseService.BaseData.EmployeeManagement
{
    //[Authorize(BaseServicePermissions.Employee.Default)]
    //public class EmployeeAppService : ApplicationService, IEmployeeAppService
    //{
    //    private readonly IRepository<Employee, Guid> _repository;
    //    private readonly IRepository<Organization, Guid> _orgRepository;
    //    private readonly IRepository<UserJobs> _empJobsRepository;
    //    private readonly IIdentityUserAppService _userAppService;

    //    public EmployeeAppService(
    //        IRepository<Employee, Guid> repository,
    //        IRepository<Organization, Guid> orgRepository,
    //        IIdentityUserAppService userAppService,
    //        IRepository<UserJobs> empJobsRepository)
    //    {
    //        _repository = repository;
    //        _orgRepository = orgRepository;
    //        _userAppService = userAppService;
    //        _empJobsRepository = empJobsRepository;
    //    }

    //    [Authorize(BaseServicePermissions.Employee.Create)]
    //    public async Task<EmployeeDto> Create(CreateOrUpdateEmployeeDto input)
    //    {
    //        var exist = await _repository.FirstOrDefaultAsync(_ => _.Name == input.Name);
    //        if (exist != null)
    //        {
    //            throw new BusinessException("名称：" + input.Name + "职员已存在！");
    //        }

    //        var user = await _repository.FirstOrDefaultAsync(_ => _.UserId == input.UserId);
    //        if (user != null)
    //        {
    //            throw new BusinessException("用户已关联，请重新选择！");
    //        }

    //        var result = await _repository.InsertAsync(new Employee(GuidGenerator.Create(), input.Name, input.Gender, input.Phone, input.Email, input.Enabled, input.OrgId, input.UserId));
    //        foreach (var jid in input.Jobs)
    //        {
    //            await _empJobsRepository.InsertAsync(new UserJobs(result.Id, jid));
    //        }

    //        return ObjectMapper.Map<Employee, EmployeeDto>(result);
    //    }

    //    [Authorize(BaseServicePermissions.Employee.Delete)]
    //    public async Task Delete(List<Guid> ids)
    //    {
    //        foreach (var id in ids)
    //        {
    //            await _repository.DeleteAsync(id);
    //        }
    //    }

    //    public async Task<EmployeeDto> Get(Guid id)
    //    {
    //        var employee = await _repository.GetAsync(id);
    //        var empJobs = await _empJobsRepository.Where(_ => _.EmployeeId == id).Select(_ => _.JobId).ToListAsync();

    //        var dto = ObjectMapper.Map<Employee, EmployeeDto>(employee);
    //        dto.Jobs = empJobs;

    //        //if (employee.UserId.HasValue)
    //        //{
    //        //    var user = await _userAppService.GetAsync(employee.UserId.Value);
    //        //    dto.UserIdToName = user?.UserName;
    //        //}

    //        return dto;
    //    }

    //    public async Task<PagedResultDto<EmployeeDto>> GetAll(GetEmployeeInputDto input)
    //    {
    //        var query = _repository.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), _ => _.Name.Contains(input.Filter));
    //        if (input.OrgId.HasValue)
    //        {
    //            var org = await _orgRepository.GetAsync(input.OrgId.Value);
    //            var orgIds = await _orgRepository.Where(_ => _.CascadeId.Contains(org.CascadeId)).Select(_=>_.Id).ToListAsync();
    //            query = query.Where(_ => orgIds.Contains(_.OrgId));
    //        }

    //        var totalCount = await query.CountAsync();
    //        var items = await query.OrderBy(input.Sorting ?? "Name")
    //                    .ToListAsync();

    //        var orgs = await _orgRepository.Where(_ => items.Select(i => i.OrgId).Contains(_.Id)).ToListAsync();

    //        var dots = ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(items);
    //        foreach (var dto in dots)
    //        {
    //            dto.OrgIdToName = orgs.FirstOrDefault(_ => _.Id == dto.OrgId)?.Name;
    //        }
    //        return new PagedResultDto<EmployeeDto>(totalCount, dots);
    //    }

    //    [Authorize(BaseServicePermissions.Employee.Update)]
    //    public async Task<EmployeeDto> Update(Guid id, CreateOrUpdateEmployeeDto input)
    //    {
    //        var employee = await _repository.GetAsync(id);
    //        if (employee.UserId != input.UserId)
    //        {
    //            var user = await _repository.FirstOrDefaultAsync(_ => _.UserId == input.UserId);
    //            if (user != null) { throw new BusinessException("用户已关联，请重新选择！"); }
    //        }

    //        employee.Name = input.Name;
    //        employee.Enabled = input.Enabled;
    //        employee.Email = input.Email;
    //        employee.Gender = input.Gender;
    //        employee.OrgId = input.OrgId;
    //        employee.UserId = input.UserId;

    //        await _empJobsRepository.DeleteAsync(_ => _.EmployeeId == employee.Id);
    //        foreach (var jid in input.Jobs)
    //        {
    //            await _empJobsRepository.InsertAsync(new UserJobs(employee.Id, jid));
    //        }

    //        return ObjectMapper.Map<Employee, EmployeeDto>(employee);
    //    }
    //}
}
