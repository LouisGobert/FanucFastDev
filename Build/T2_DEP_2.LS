/PROG  T2_DEP_2
/ATTR
OWNER       = MNEDITOR;
COMMENT     = "";
PROG_SIZE   = 1382;
CREATE      = DATE 20-10-15  TIME 15:42:30;
MODIFIED    = DATE 20-10-15  TIME 16:10:46;
FILE_NAME   = ;
VERSION     = 0;
LINE_COUNT  = 17;
MEMORY_SIZE = 1662;
PROTECT     = READ_WRITE;
TCD:  STACK_SIZE        = 0,
      TASK_PRIORITY     = 50,
      TIME_SLICE        = 0,
      BUSY_LAMP_OFF     = 0,
      ABORT_REQUEST     = 0,
      PAUSE_REQUEST     = 0;
DEFAULT_GROUP   = 1,*,*,*,*;
CONTROL_CODE    = 00000000 00000000;
/APPL
/MN
   1:  !fg ;
   2:   ;
   3:  UFRAME_NUM=1 ;
   4:  UTOOL_NUM=3 ;
   5:   ;
   6:   ;
   7:J PR[41] 100% CNT50    ;
   8:   ;
   9:  !f ;
  10:  R[51]=R[53]    ;
  11:   ;
  12:J PR[21:depot-calc] 100% CNT2    ;
  13:L PR[21:depot-calc] 100mm/sec FINE Offset,PR[50:Hauteur approche]    ;
  14:  CALL M2_OUVERTURE_PINCE    ;
  15:L PR[21:depot-calc] 100mm/sec FINE Offset,PR[50:Hauteur approche]    ;
  16:   ;
  17:   ;
/POS
/END
