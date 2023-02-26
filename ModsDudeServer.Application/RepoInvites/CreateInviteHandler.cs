﻿using ModsDudeServer.Application.Commands;
using ModsDudeServer.Application.RepoInvites.Exceptions;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.RepoInvites;
public class CreateInviteHandler : ICommandHandler<CreateInviteCommand>
{
    private readonly ApplicationDbContext _dbContext;


    public CreateInviteHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void Handle(CreateInviteCommand command)
    {
        foreach (RepoId repoId in command.RepoIds)
        {
            if (CheckRepoExists(repoId) == false)
            {
                throw new RepoNotFoundException(repoId);
            }
        }

        Invite invite = new(command.MembershipLevel, command.Expires, command.MultiUse);

        _dbContext.Invites.Add(invite);

        _dbContext.SaveChanges();
    }


    private bool CheckRepoExists(RepoId repoId)
    {
        return _dbContext.Repos.Any(repo => repo.Id == repoId);
    }
}