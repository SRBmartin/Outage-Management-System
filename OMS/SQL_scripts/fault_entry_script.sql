CREATE TABLE reported_faults(
    fid varchar2(32) NOT NULL,
    date_of_fault varchar2(10) DEFAULT TO_CHAR(SYSDATE, 'yyyy-MM-dd') NOT NULL,
    fstatus varchar(32) DEFAULT 'Unconfirmed',
    fshort_desc varchar2(256) NOT NULL,
    ecid integer NOT NULL,
    fdesc varchar(1024) NOT NULL
);
ALTER TABLE reported_faults
ADD (
    constraint rp_pk PRIMARY KEY (fid),
    constraint rp_ck CHECK (fstatus IN ('Unconfirmed', 'In service', 'Testing', 'Closed')),
    constraint rp_fk FOREIGN KEY (ecid) REFERENCES electronic_components(ecid)
);
CREATE SEQUENCE reported_faults_seq
    START WITH 1
    INCREMENT BY 1
    NOMAXVALUE
    NOCYCLE
    CACHE 20;
CREATE OR REPLACE TRIGGER reported_faults_trigger
BEFORE INSERT ON reported_faults
FOR EACH ROW
DECLARE
    last_date DATE;
    new_sequence NUMBER;
BEGIN
    SELECT MAX(TO_DATE(SUBSTR(fid, 1, 14), 'YYYYMMDDHH24MISS'))
    INTO last_date
    FROM reported_faults;

    IF last_date IS NULL OR TRUNC(last_date) <> TRUNC(SYSDATE) THEN
        -- Reset sequence for a new date
        SELECT reported_faults_seq.NEXTVAL INTO new_sequence FROM DUAL;
    ELSE
        -- Increment sequence for the same date
        SELECT reported_faults_seq.NEXTVAL INTO new_sequence FROM DUAL;
    END IF;

    :NEW.fid := TO_CHAR(SYSDATE, 'YYYYMMDDHH24MISS') || '_' || TO_CHAR(new_sequence, 'FM000000');
END;
/
