﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroLAN
{
    [Serializable]
    internal class SocketData
    {
        public int Command { get; set; }
        public string Message { get; set; }
        public Point? Point { get; set; }
        public SocketData(int command, string message, Point? point)
        {
            Command = command;
            Message = message;
            Point = point;
        }
    }
    public enum SocketCommand
    {
        SEND_POINT,
        INIT_DATA,
        SEND_NAME,
        NOTIFY,
        NEW_GAME,
        UNDO,
        END_GAME,
        TIME_OUT,
        QUIT,
        CHANGE_FIRST_PLAYER
    }
}
