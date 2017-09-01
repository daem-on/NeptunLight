﻿using System;
using NeptunLight.Models;
using ReactiveUI;

namespace NeptunLight.ViewModels
{
    public class MessageViewModel : PageViewModel
    {
        private readonly ObservableAsPropertyHelper<string> _senderCode;

        private DateTime _date;
        private string _htmlContent;
        private string _sender;
        private string _title;

        public MessageViewModel(Mail model)
        {
            Date = model.ReceivedTime;
            Title = model.Subject;
            Sender = model.Sender;
            HtmlContent = model.Content;
            this.WhenAny(x => x.Sender, sender => string.IsNullOrEmpty(sender.Value) ? String.Empty : sender.Value.ToUpper().Substring(0, 1)).ToProperty(this, x => x.SenderCode, out _senderCode);
        }

        public DateTime Date
        {
            get => _date;
            set => this.RaiseAndSetIfChanged(ref _date, value);
        }

        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public string HtmlContent
        {
            get => _htmlContent;
            set => this.RaiseAndSetIfChanged(ref _htmlContent, value);
        }

        public string Sender
        {
            get => _sender;
            set => this.RaiseAndSetIfChanged(ref _sender, value);
        }

        public string SenderCode => _senderCode.Value;
    }
}