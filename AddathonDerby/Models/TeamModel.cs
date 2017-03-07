namespace AddathonDerby.Models
{
    public class TeamModel
    {
        public string ErrorMessage { get; set; }

        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string Password { get; set; }

        public int Slot1 { get; set; }

        public int Slot2 { get; set; }

        public int Slot3 { get; set; }

        public int Slot4 { get; set; }

        public int Slot5 { get; set; }

        public int Slot6 { get; set; }

        public int Slot7 { get; set; }

        public int Slot8 { get; set; }

        public int Slot9 { get; set; }

        public int Slot10 { get; set; }

        public int Slot11 { get; set; }

        public int Slot12 { get; set; }

        public int Slot13 { get; set; }

        public int Slot14 { get; set; }

        public int Slot15 { get; set; }

        public int Slot16 { get; set; }

        public int Slot17 { get; set; }

        public int Slot18 { get; set; }

        public int Slot19 { get; set; }

        public int Slot20 { get; set; }

        public int Slot21 { get; set; }

        public int Slot22 { get; set; }

        public int Slot23 { get; set; }

        public int Slot24 { get; set; }

        public int Slot25 { get; set; }

        public int Slot26 { get; set; }

        public int Slot27 { get; set; }

        public int Slot28 { get; set; }

        public int Slot29 { get; set; }

        public int Slot30 { get; set; }

        public int Slot31 { get; set; }

        public int Slot32 { get; set; }

        public int Slot33 { get; set; }

        public int Slot34 { get; set; }

        public int Slot35 { get; set; }

        public int Slot36 { get; set; }

        public int Slot37 { get; set; }

        public int Slot38 { get; set; }

        public int Slot39 { get; set; }

        public int Slot40 { get; set; }

        public int Slot41 { get; set; }

        public int Slot42 { get; set; }

        public int Slot43 { get; set; }

        public int Slot44 { get; set; }

        public int Slot45 { get; set; }

        public int Slot46 { get; set; }

        public int Slot47 { get; set; }

        public int Slot48 { get; set; }

        public int Slot49 { get; set; }

        public int Slot50 { get; set; }

        public int Score
        {
            get
            {
                int result = Slot1 + Slot2 + Slot3 + Slot4 + Slot5 + Slot6 + Slot7 + Slot8 + Slot9 + Slot10;
                result += Slot11 + Slot12 + Slot13 + Slot14 + Slot15 + Slot16 + Slot17 + Slot18 + Slot19 + Slot20;
                result += Slot21 + Slot22 + Slot23 + Slot24 + Slot25 + Slot26 + Slot27 + Slot28 + Slot29 + Slot30;
                result += Slot31 + Slot32 + Slot33 + Slot34 + Slot35 + Slot36 + Slot37 + Slot38 + Slot39 + Slot40;
                result += Slot41 + Slot42 + Slot43 + Slot44 + Slot45 + Slot46 + Slot47 + Slot48 + Slot49 + Slot50;
                return result;
            }
        }

        public void SetScore(int slot, int score)
        {
            switch (slot)
            {
                case 1: Slot1 = score; break;
                case 2: Slot2 = score; break;
                case 3: Slot3 = score; break;
                case 4: Slot4 = score; break;
                case 5: Slot5 = score; break;
                case 6: Slot6 = score; break;
                case 7: Slot7 = score; break;
                case 8: Slot8 = score; break;
                case 9: Slot9 = score; break;
                case 10: Slot10 = score; break;
                case 11: Slot11 = score; break;
                case 12: Slot12 = score; break;
                case 13: Slot13 = score; break;
                case 14: Slot14 = score; break;
                case 15: Slot15 = score; break;
                case 16: Slot16 = score; break;
                case 17: Slot17 = score; break;
                case 18: Slot18 = score; break;
                case 19: Slot19 = score; break;
                case 20: Slot20 = score; break;
                case 21: Slot21 = score; break;
                case 22: Slot22 = score; break;
                case 23: Slot23 = score; break;
                case 24: Slot24 = score; break;
                case 25: Slot25 = score; break;
                case 26: Slot26 = score; break;
                case 27: Slot27 = score; break;
                case 28: Slot28 = score; break;
                case 29: Slot29 = score; break;
                case 30: Slot30 = score; break;
                case 31: Slot31 = score; break;
                case 32: Slot32 = score; break;
                case 33: Slot33 = score; break;
                case 34: Slot34 = score; break;
                case 35: Slot35 = score; break;
                case 36: Slot36 = score; break;
                case 37: Slot37 = score; break;
                case 38: Slot38 = score; break;
                case 39: Slot39 = score; break;
                case 40: Slot40 = score; break;
                case 41: Slot41 = score; break;
                case 42: Slot42 = score; break;
                case 43: Slot43 = score; break;
                case 44: Slot44 = score; break;
                case 45: Slot45 = score; break;
                case 46: Slot46 = score; break;
                case 47: Slot47 = score; break;
                case 48: Slot48 = score; break;
                case 49: Slot49 = score; break;
                case 50: Slot50 = score; break;
            }
        }

        public int GetScore(int slot)
        {
            switch (slot)
            {
                case 1: return Slot1;
                case 2: return Slot2;
                case 3: return Slot3;
                case 4: return Slot4;
                case 5: return Slot5;
                case 6: return Slot6;
                case 7: return Slot7;
                case 8: return Slot8;
                case 9: return Slot9;
                case 10: return Slot10;
                case 11: return Slot11;
                case 12: return Slot12;
                case 13: return Slot13;
                case 14: return Slot14;
                case 15: return Slot15;
                case 16: return Slot16;
                case 17: return Slot17;
                case 18: return Slot18;
                case 19: return Slot19;
                case 20: return Slot20;
                case 21: return Slot21;
                case 22: return Slot22;
                case 23: return Slot23;
                case 24: return Slot24;
                case 25: return Slot25;
                case 26: return Slot26;
                case 27: return Slot27;
                case 28: return Slot28;
                case 29: return Slot29;
                case 30: return Slot30;
                case 31: return Slot31;
                case 32: return Slot32;
                case 33: return Slot33;
                case 34: return Slot34;
                case 35: return Slot35;
                case 36: return Slot36;
                case 37: return Slot37;
                case 38: return Slot38;
                case 39: return Slot39;
                case 40: return Slot40;
                case 41: return Slot41;
                case 42: return Slot42;
                case 43: return Slot43;
                case 44: return Slot44;
                case 45: return Slot45;
                case 46: return Slot46;
                case 47: return Slot47;
                case 48: return Slot48;
                case 49: return Slot49;
                case 50: return Slot50;
            }
            return 0;
        }

        public string Checked(int slot, int score) { return slot == score ? "checked" : ""; }

    }
}