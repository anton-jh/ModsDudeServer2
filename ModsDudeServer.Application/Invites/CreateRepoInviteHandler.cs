﻿using ModsDudeServer.Application.Commands;
using ModsDudeServer.Application.Invites.Exceptions;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Repo;
using ModsDudeServer.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Invites;
public class CreateRepoInviteHandler : ICommandHandler<CreateRepoInviteCommand>
{
    private readonly ApplicationDbContext _dbContext;


    public CreateRepoInviteHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void Handle(CreateRepoInviteCommand command)
    {
        if (CheckRepoExists(command.RepoId) == false)
        {
            throw new RepoNotFoundException(command.RepoId);
        }

        RepoInvite repoInvite = new(command.RepoId, command.MembershipLevel, command.Expires, command.MultiUse);

        _dbContext.RepoInvites.Add(repoInvite);

        _dbContext.SaveChanges();
    }


    private bool CheckRepoExists(RepoId repoId)
    {
        return _dbContext.Repos.Any(repo => repo.Id == repoId);
    }
}
