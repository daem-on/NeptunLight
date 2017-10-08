﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NeptunLight.Models;

namespace NeptunLight.DataAccess
{
    public interface INeptunInterface
    {
        Uri BaseUri { get; set; }
        string Username { get; set; }

        string Password { get; set; }

        Task LoginAsync();

        Task<IReadOnlyCollection<Mail>> RefreshMessagesAsnyc(IProgress<MessageLoadingProgress> progress = null);
        Task<IReadOnlyCollection<CalendarEvent>> RefreshCalendarAsnyc();
        Task<IReadOnlyDictionary<Semester, IReadOnlyCollection<Subject>>> RefreshSubjectsAsnyc();
        Task<IReadOnlyDictionary<Semester, IReadOnlyCollection<Exam>>> RefreshExamsAsnyc();
        Task<IReadOnlyCollection<SemesterData>> RefreshSemestersAsnyc();
        Task<IReadOnlyCollection<Period>> RefreshPeriodsAsnyc();
    }
}