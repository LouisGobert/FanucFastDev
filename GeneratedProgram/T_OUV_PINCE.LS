/PROG  T_OUV_PINCE
/ATTR
OWNER       = MNEDITOR;
COMMENT     = "";
PROG_SIZE   = 1382;
CREATE      = DATE 20-10-15  TIME 15:42:30;
MODIFIED    = DATE 20-10-15  TIME 16:10:46;
FILE_NAME   = ;
VERSION     = 0;
LINE_COUNT  = 4;
MEMORY_SIZE = 1662;
PROTECT     = READ_WRITE;
TCD:  STACK_SIZE        = 0,
      TASK_PRIORITY     = 50,
      TIME_SLICE        = 0,
      BUSY_LAMP_OFF     = 0,
      ABORT_REQUEST     = 0,
      PAUSE_REQUEST     = 0;
DEFAULT_GROUP   = *,*,*,*,*;
CONTROL_CODE    = 00000000 00000000;
/APPL
/MN
   1:  !B2 - Lecat Gobert ;
   2:  RO[7]=ON ;
   3:  RO[8]=OFF ;
   4:  WAIT   1.00(sec) ;
/POS
/END
