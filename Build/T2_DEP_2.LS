/PROG  T2_DEP_2
/ATTR
OWNER       = MNEDITOR;
COMMENT     = "";
PROG_SIZE   = 1382;
CREATE      = DATE 20-10-15  TIME 15:42:30;
MODIFIED    = DATE 20-10-15  TIME 16:10:46;
FILE_NAME   = ;
VERSION     = 0;
LINE_COUNT  = 25;
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
   1:  !louis ;
   2:   ;
   3:  UFRAME_NUM=1 ;
   4:  UTOOL_NUM=3 ;
   5:   ;
   6:  IF (RO[1]) THEN ;
   7:   ;
   8:  ENDIF ;
   9:   ;
  10:  IF (RO[12] AND RO[11]) THEN ;
  11:   ;
  12:  ENDIF ;
  13:   ;
  14:   ;
  15:J PR[41] 100% CNT50    ;
  16:   ;
  17:  !louis ;
  18:  R[51]=R[53]    ;
  19:   ;
  20:J PR[21:depot-calc] 100% CNT2    ;
  21:L PR[21:depot-calc] 100mm/sec FINE Offset,PR[50:Hauteur approche]    ;
  22:  CALL M2_OUVERTURE_PINCE    ;
  23:L PR[21:depot-calc] 100mm/sec FINE Offset,PR[50:Hauteur approche]    ;
  24:   ;
  25:   ;
/POS
/END
