using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analyzer_TF_1
{
    static class Analyzer_T
    {
        enum States
        {
            S, F, E,
            OOBI0, OOBI1, OOBI2, // OUT OF BOUNDS IDENTIFICATORS
            V, VA, VAR, //VAR
            F1, FI, FIL, FILE, //FILE
            T, TE, TEX, TEXT,  // TEXT
            O, OF,
            D, DO, DOU, DOU1, DOU2, DOU3, //DOUBLE
            B, BY, BYT, BYTE,
            C, CH, CHA, CHAR,
            R, RE, REA, REAL,
            I, IN, INT, INT1, INT2, INT3, INT4, // INTEGER
            S1, SI, SIN, SIN1, SIN2, SIN3,  //SINGLE
            ST, STR, STR1, STR2, STR3,  //STRING
            SP0, SP1, SP2, SP3, SP4, SP5, SP6, SP7, SPF, //SPACES
            I0, I1, I2, D0, SC1, CO, SC2, //IDENTIFICATORS, DIVIDES AND OTHER.
        };

        public static bool Check(string S, TextBox textBox1, ListBox list1, ListBox list2)
        {
            States State = States.S;
            list1.Items.Clear();
            list2.Items.Clear();
            int pos = 0;
            string ErrorMessage = "";
            string idtype1 = "";
            string idtype2 = "";
            string id = "";
            string conste = "";
            while (pos < S.Length && State != States.F && State != States.E)
            {
                switch (State)
                {
                    case States.S:
                        {
                            if (S[pos] == 'V') State = States.V;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: S - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.V:
                        {
                            if (S[pos] == 'A') State = States.VA;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: V- ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.VA:
                        {
                            if (S[pos] == 'R') State = States.VAR;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: VA - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.VAR:
                        {
                            if (S[pos] == ' ') State = States.SP0;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: VAR - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.SP0:
                        {
                            if (S[pos] == ' ') State = States.SP0;
                            else if ((S[pos] == '_') || Char.IsLetter(S[pos]))
                            { State = States.I0; id += S[pos]; }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: пробел опосля VAR - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.I0:
                        {
                            if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            { State = States.I0; id += S[pos]; }
                            else if (S[pos] == ' ')
                            { State = States.SP1; }
                            else if (S[pos] == ':')
                            { State = States.D0; }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: идентификатор №0 - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.SP1:
                        {
                            if (S[pos] == ' ') State = States.SP1;
                            else if (S[pos] == ':') State = States.D0;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: пробел после идентификатора №0 - ошибка дальнейшего анализа!";
                            }
                            if (id.Length > 8)
                            {
                                State = States.E;
                                ErrorMessage = "Превышена допустимая длина для первого идентификатора!";
                            }
                            if ((id == "BYTE") || (id == "CHAR") || (id == "REAL") || (id == "STRING") || (id == "SINGLE") || (idtype1 == "INTEGER") || (id == "DOUBLE") || (id == "VAR") || (id == "FILE OF") || (id == "TEXT") || (id == "FILE"))
                            {
                                State = States.E;
                                ErrorMessage = "Идентификатор №0 является зарезервированным словом!";
                            }
                            break;
                        }
                    case States.D0:
                        {
                            if (S[pos] == ' ') State = States.SP2; //добавить переход без пробела
                            else if (S[pos] == 'F') State = States.F1;
                            else if (S[pos] == 'T') State = States.T;
                            else if ((S[pos] == '_') || Char.IsLetter(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: двоеточие - ошибка дальнейшего анализа!";
                            }
                            if (id.Length > 8)
                            {
                                State = States.E;
                                ErrorMessage = "Превышена допустимая длина для первого идентификатора!";
                            }
                            if ((id == "BYTE") || (id == "CHAR") || (id == "REAL") || (id == "STRING") || (id == "SINGLE") || (idtype1 == "INTEGER") || (id == "DOUBLE") || (id == "VAR") || (id == "FILE OF") || (id == "TEXT") || (id == "FILE"))
                            {
                                State = States.E;
                                ErrorMessage = "Идентификатор №0 является зарезервированным словом!";
                            }
                            break;
                        }
                    case States.SP2:
                        {
                            if (S[pos] == ' ') State = States.SP2;
                            else if (S[pos] == 'F') State = States.F1;
                            else if (S[pos] == 'T') State = States.T;
                            else if ((S[pos] == '_') || Char.IsLetter(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }

                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: ввод пробела после двоеточия - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    //FILE
                    case States.F1:
                        {
                            if (S[pos] == 'I') State = States.FI;
                            else if (S[pos] == ' ') State = States.SP3;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: F - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.FI:
                        {
                            if (S[pos] == 'L') State = States.FIL;
                            else if (S[pos] == ' ') State = States.SP3;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: FI - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.FIL:
                        {
                            if (S[pos] == 'E') State = States.FILE;
                            else if (S[pos] == ' ') State = States.SP3;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: FIL - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.FILE:
                        {
                            if (S[pos] == ' ') State = States.SP3;
                            else if (S[pos] == ' ') State = States.SP3;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }
                            else if (S[pos] == ';') State = States.F;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: FILE - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    //TEXT
                    case States.T:
                        {
                            if (S[pos] == 'E') State = States.TE;
                            else if (S[pos] == ' ') State = States.SP3;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: T - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.TE:
                        {
                            if (S[pos] == 'X') State = States.TEX;
                            else if (S[pos] == ' ') State = States.SP3;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: TE - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.TEX:
                        {
                            if (S[pos] == 'T') State = States.TEXT;
                            else if (S[pos] == ' ') State = States.SP3;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: TEX - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.TEXT:
                        {
                            if (S[pos] == ' ') State = States.SP3;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }
                            else if (S[pos] == ';') State = States.F;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: TEXT - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    //IDENTIFICATOR 1
                    case States.I1:
                        {
                            if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I1;
                                idtype1 += S[pos];
                            }
                            else if (S[pos] == ' ') State = States.SP3;
                            else if (S[pos] == ';')
                            {
                                if ((idtype1 == "BYTE") || (idtype1 == "CHAR") || (idtype1 == "REAL") || (idtype1 == "STRING") || (idtype1 == "SINGLE") || (idtype1 == "INTEGER") || (idtype1 == "DOUBLE") || (idtype1 == "VAR") || (idtype1 == "FILE OF") || (idtype1 == "TEXT") || (idtype1 == "FILE"))
                                {
                                    State = States.E;
                                    ErrorMessage = "Идентификатор №1 является зарезервированным словом!";
                                }
                                else State = States.F;
                                if (id != idtype1) State = States.F;
                                else
                                {
                                    State = States.E;
                                    ErrorMessage = "Совпадение идентификатора и идентификатора типа!";
                                }
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: идентификатор №1 - ошибка дальнейшего анализа!";
                            }
                            if (idtype1.Length > 8)
                            {
                                State = States.E;
                                ErrorMessage = "Превышена допустимая длина для идентификатора 1!";
                            }
                            break;
                        }
                    case States.SP3:
                        {
                            if (S[pos] == ' ') State = States.SP3;
                            else if (S[pos] == 'O') State = States.O;
                            else if (S[pos] == ';') State = States.F;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: пробел после FILE/TEXT/Идентификатора №1 - ошибка дальнейшего анализа!";
                            }
                            if (idtype1.Length > 8)
                            {
                                State = States.E;
                                ErrorMessage = "Превышена допустимая длина для идентификатора 1!";
                            }
                            if ((idtype1 == "BYTE") || (idtype1 == "CHAR") || (idtype1 == "REAL") || (idtype1 == "STRING") || (idtype1 == "SINGLE") || (idtype1 == "INTEGER") || (idtype1 == "DOUBLE") || (idtype1 == "VAR") || (idtype1 == "FILE OF") || (idtype1 == "TEXT") || (idtype1 == "FILE"))
                            {
                                State = States.E;
                                ErrorMessage = "Идентификатор является зарезервированным словом!";
                            }
                            break;
                        }

                    //OF
                    case States.O:
                        {
                            if (S[pos] == 'F') State = States.OF;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: O - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.OF:
                        {
                            if (S[pos] == ' ') State = States.SP4;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: OF - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.SP4:
                        {
                            if (S[pos] == ' ') State = States.SP4;
                            else if (S[pos] == 'B') State = States.B;
                            else if (S[pos] == 'C') State = States.C;
                            else if (S[pos] == 'R') State = States.R;
                            else if (S[pos] == 'D') State = States.D;
                            else if (S[pos] == 'I') State = States.I;
                            else if (S[pos] == 'S') State = States.S1;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: пробел после FILE OF - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    // BYTE
                    case States.B:
                        {
                            if (S[pos] == 'Y') State = States.BY;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: B - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.BY:
                        {
                            if (S[pos] == 'T') State = States.BYT;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: BY - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.BYT:
                        {
                            if (S[pos] == 'E') State = States.BYTE;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: BYT - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.BYTE:
                        {
                            if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: BYTE - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    // CHAR
                    case States.C:
                        {
                            if (S[pos] == 'H') State = States.CH;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: C - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.CH:
                        {
                            if (S[pos] == 'A') State = States.CHA;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: CH - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.CHA:
                        {
                            if (S[pos] == 'R') State = States.CHAR;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: CHA - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.CHAR:
                        {
                            if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: CHAR - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    // REAL
                    case States.R:
                        {
                            if (S[pos] == 'E') State = States.RE;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: R - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.RE:
                        {
                            if (S[pos] == 'A') State = States.REA;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: RE - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.REA:
                        {
                            if (S[pos] == 'L') State = States.REAL;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: REA - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.REAL:
                        {
                            if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: REAL - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    // DOUBLE
                    case States.D:
                        {
                            if (S[pos] == 'O') State = States.DO;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: D - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.DO:
                        {
                            if (S[pos] == 'U') State = States.DOU;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: DO - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.DOU:
                        {
                            if (S[pos] == 'B') State = States.DOU1;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: DOU - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.DOU1:
                        {
                            if (S[pos] == 'L') State = States.DOU2;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: DOUB - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.DOU2:
                        {
                            if (S[pos] == 'E') State = States.DOU3;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: DOUBL - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.DOU3:
                        {
                            if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: DOUBLE - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    // INTEGER
                    case States.I:
                        {
                            if (S[pos] == 'N') State = States.IN;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: I - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.IN:
                        {
                            if (S[pos] == 'T') State = States.INT;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: IN - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.INT:
                        {
                            if (S[pos] == 'E') State = States.INT1;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: INT - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.INT1:
                        {
                            if (S[pos] == 'G') State = States.INT2;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: INTE - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.INT2:
                        {
                            if (S[pos] == 'E') State = States.INT3;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: INTEG - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.INT3:
                        {
                            if (S[pos] == 'R') State = States.INT4;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: INTEGE - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.INT4:
                        {
                            if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: INTEGER - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    // SINGLE or STRING
                    case States.S1:
                        {
                            if (S[pos] == 'I') State = States.SI;
                            else if (S[pos] == 'T') State = States.ST;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: S - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.SI:
                        {
                            if (S[pos] == 'N') State = States.SIN;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: SI - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.SIN:
                        {
                            if (S[pos] == 'G') State = States.SIN1;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: SIN - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.SIN1:
                        {
                            if (S[pos] == 'L') State = States.SIN2;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: SING - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.SIN2:
                        {
                            if (S[pos] == 'E') State = States.SIN3;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: SINGL - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.SIN3:
                        {
                            if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: SINGLE - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    //STRING
                    case States.ST:
                        {
                            if (S[pos] == 'R') State = States.STR;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: ST - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.STR:
                        {
                            if (S[pos] == 'I') State = States.STR1;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: STR - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.STR1:
                        {
                            if (S[pos] == 'N') State = States.STR2;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: STRI - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.STR2:
                        {
                            if (S[pos] == 'G') State = States.STR3;
                            else if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: STRIN - ошибка дальнейшего анализа!";
                            }
                            break;
                        }
                    case States.STR3:
                        {
                            if (S[pos] == ' ') State = States.SP5;
                            else if (S[pos] == ';') State = States.F;
                            else if (S[pos] == '[') State = States.SC1;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: STRING - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    // IDENTIFICATOR 2
                    case States.I2:
                        {
                            if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else if ((S[pos] == '_') || Char.IsLetterOrDigit(S[pos]))
                            {
                                State = States.I2;
                                idtype2 += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: Идентификатор №2 - ошибка дальнейшего анализа!";
                            }
                            if (idtype2.Length > 8)
                            {
                                State = States.E;
                                ErrorMessage = "Превышена допустимая длина для идентификатора №2!";
                            }
                            break;
                        }

                    case States.SP5:
                        {
                            if (S[pos] == ' ') State = States.SP5;
                            else if (S[pos] == '[') State = States.SC1;
                            else if (S[pos] == ';') State = States.F;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: пробел после идентификатора типа - ошибка дальнейшего анализа!";
                            }
                            if (idtype2.Length > 8)
                            {
                                State = States.E;
                                ErrorMessage = "Превышена допустимая длина для идентификатора №2!";
                            }
                            break;
                        }

                    case States.SC1:
                        {
                            if (S[pos] == ' ') State = States.SC1;
                            else if (S[pos] == '0')
                            {
                                State = States.SP6;
                                conste = "0";
                            }
                            else if (Char.IsDigit(S[pos]))
                            {
                                State = States.CO;
                                conste += S[pos];
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: открывающая скобка для указателя длины - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    case States.CO:
                        {
                            if (Char.IsDigit(S[pos]))
                            {
                                State = States.CO;
                                conste += S[pos];
                            }
                            else if (S[pos] == ' ') State = States.SP6;
                            else if (S[pos] == ']')
                            {
                                if ((Convert.ToInt32(conste) <= 255) && (Convert.ToInt32(conste) >= 0))
                                    State = States.SC2;
                                else
                                {
                                    State = States.E;
                                    ErrorMessage = "Превышена допустимая длина строки!";
                                }
                            }
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: указатель длины для типа string - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    case States.SP6:
                        {
                            if (S[pos] == ' ') State = States.SP6;
                            else if (S[pos] == ']') State = States.SC2;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: пробел после указателя длины перед закрывающей скобкой - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    case States.SC2:
                        {
                            if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: закрывающая скобка - ошибка дальнейшего анализа!";
                            }
                            list2.Items.Add(conste);
                            break;
                        }

                    case States.SP7:
                        {
                            if (S[pos] == ' ') State = States.SP7;
                            else if (S[pos] == ';') State = States.F;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: пробел после закрывающей скобки - ошибка дальнейшего анализа!";
                            }
                            break;
                        }

                    case States.SPF:
                        {
                            if (S[pos] == ' ') State = States.SPF;
                            else if (S[pos] == ';') State = States.F;
                            else
                            {
                                State = States.E;
                                ErrorMessage = "Последнее состояние: пробел перед точкой с запятой - ошибка дальнейшего анализа!";
                            }
                            if ((idtype1 == "BYTE") || (idtype1 == "CHAR") || (idtype1 == "REAL") || (idtype1 == "STRING") || (idtype1 == "SINGLE") || (idtype1 == "INTEGER") || (idtype1 == "DOUBLE") || (idtype1 == "VAR") || (idtype1 == "FILE OF") || (idtype1 == "TEXT") || (idtype1 == "FILE"))
                            {
                                State = States.E;
                                ErrorMessage = "Идентификатор №1 является зарезервированным словом!";
                            }
                            if ((idtype2 == "BYTE") || (idtype2 == "CHAR") || (idtype2 == "REAL") || (idtype2 == "STRING") || (idtype2 == "SINGLE") || (idtype2 == "INTEGER") || (idtype2 == "DOUBLE") || (idtype2 == "VAR") || (idtype2 == "FILE OF") || (idtype2 == "TEXT") || (idtype2 == "FILE"))
                            {
                                State = States.E;
                                ErrorMessage = "Идентификатор №2 является зарезервированным словом!";
                            }
                            break;
                        }
                }
                pos++;

            }
            textBox1.Text = ErrorMessage;
            list1.Items.Add(id);
            list1.Items.Add(idtype1);
            list1.Items.Add(idtype2);
            return (State == States.F);
        }

    }
}
