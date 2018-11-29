BEGIN

    BEGIN
            EXECUTE IMMEDIATE 'ALTER TABLE aluno 
                                    DROP CONSTRAINT fk_cidade';
            EXECUTE IMMEDIATE 'ALTER TABLE registro_academico
                                    DROP CONSTRAINT fk_regacad_aluno
                                    DROP CONSTRAINT fk_regacad_curso';
            EXECUTE IMMEDIATE 'ALTER TABLE registro_academico_disciplina
                                    DROP CONSTRAINT fk_regacad_disc
                                    DROP CONSTRAINT fk_regacad_reg';
            EXECUTE IMMEDIATE 'ALTER TABLE nota
                                    DROP CONSTRAINT fk_regacadnota_disc
                                    DROP CONSTRAINT fk_regacad_nota';
        EXCEPTION
            WHEN OTHERS THEN
                NULL;
        END;

	BEGIN
        BEGIN
            EXECUTE IMMEDIATE 'DROP TABLE usuario';
        EXCEPTION
            WHEN OTHERS THEN
                IF sqlcode != -942 THEN
                    RAISE;
                END IF;
        END;

        EXECUTE IMMEDIATE 'CREATE TABLE usuario (
		nome     VARCHAR(8) NOT NULL,
		senha VARCHAR(5)
		)';
    END;

    BEGIN
        BEGIN
            EXECUTE IMMEDIATE 'DROP TABLE cidade';
        EXCEPTION
            WHEN OTHERS THEN
                IF sqlcode != -942 THEN
                    RAISE;
                END IF;
        END;

        EXECUTE IMMEDIATE 'CREATE TABLE cidade (
        codigo   INT NOT NULL,
        nome     VARCHAR(100) DEFAULT NULL,
        uf       VARCHAR(2) DEFAULT NULL,
        PRIMARY KEY ( codigo )
        )';
    END;

    BEGIN
        BEGIN
            EXECUTE IMMEDIATE 'DROP TABLE aluno';
        EXCEPTION
            WHEN OTHERS THEN
                IF sqlcode != -942 THEN
                    RAISE;
                END IF;
        END;

        EXECUTE IMMEDIATE 'CREATE TABLE aluno (
        codigo           INT NOT NULL PRIMARY KEY,
        nome             VARCHAR(75) NOT NULL,
        sobrenome        VARCHAR(125) NOT NULL,
        codcidade        INT DEFAULT NULL,
        cpf              VARCHAR(15) DEFAULT NULL,
        datanascimento   DATE DEFAULT NULL,
        CONSTRAINT fk_cidade FOREIGN KEY ( codcidade )
            REFERENCES cidade ( codigo )
        )';
    END;
    
    BEGIN
        BEGIN
            EXECUTE IMMEDIATE 'DROP TABLE curso';
        EXCEPTION
            WHEN OTHERS THEN
                IF sqlcode != -942 THEN
                    RAISE;
                END IF;
        END;

        EXECUTE IMMEDIATE 'CREATE TABLE curso (
        cod             INT NOT NULL,
        nome           VARCHAR(75) DEFAULT NULL,
        datainicio     DATE DEFAULT NULL,
        cargahoraria   DECIMAL DEFAULT NULL,
        PRIMARY KEY ( cod )
        )';
    END;
    
    BEGIN
        BEGIN
            EXECUTE IMMEDIATE 'DROP TABLE disciplina';
        EXCEPTION
            WHEN OTHERS THEN
                IF sqlcode != -942 THEN
                    RAISE;
                END IF;
        END;

        EXECUTE IMMEDIATE 'CREATE TABLE disciplina (
        cod      INT NOT NULL,
        nome    VARCHAR(75) DEFAULT NULL,
        valor   DECIMAL DEFAULT NULL,
        PRIMARY KEY ( cod )
        )';
    END;
    
     BEGIN
        BEGIN
            EXECUTE IMMEDIATE 'DROP TABLE registro_academico';
        EXCEPTION
            WHEN OTHERS THEN
                IF sqlcode != -942 THEN
                    RAISE;
                END IF;
        END;

        EXECUTE IMMEDIATE 'CREATE TABLE registro_academico (
        cod                 INT NOT NULL,
        numero_matricula   INT DEFAULT NULL,
        semestre           VARCHAR(10) DEFAULT NULL,
        cod_aluno           INT DEFAULT NULL,
        cod_curso           INT DEFAULT NULL,
        PRIMARY KEY ( cod ),
        CONSTRAINT fk_regacad_aluno FOREIGN KEY ( cod_aluno )
            REFERENCES aluno ( codigo ),
        CONSTRAINT fk_regacad_curso FOREIGN KEY ( cod_curso )
            REFERENCES curso ( cod )
        )';
    END;
    
    BEGIN
        BEGIN
            EXECUTE IMMEDIATE 'DROP TABLE registro_academico_disciplina';
        EXCEPTION
            WHEN OTHERS THEN
                IF sqlcode != -942 THEN
                    RAISE;
                END IF;
        END;

        EXECUTE IMMEDIATE 'CREATE TABLE registro_academico_disciplina (
        cod                 INT NOT NULL,
        cod_reg_academico   INT DEFAULT NULL,
        cod_disciplina      INT DEFAULT NULL,
        PRIMARY KEY ( cod ),
        CONSTRAINT fk_regacad_disc FOREIGN KEY ( cod_disciplina )
            REFERENCES disciplina ( cod ),
        CONSTRAINT fk_regacad_reg FOREIGN KEY ( cod_reg_academico )
            REFERENCES registro_academico ( cod )
        )';
    END;
    
    BEGIN
        BEGIN
            EXECUTE IMMEDIATE 'DROP TABLE nota';
        EXCEPTION
            WHEN OTHERS THEN
                IF sqlcode != -942 THEN
                    RAISE;
                END IF;
        END;

        EXECUTE IMMEDIATE 'CREATE TABLE nota (
        cod             INT NOT NULL,
        codregacad      INT DEFAULT NULL,
        coddisciplina   INT DEFAULT NULL,
        nota1           DECIMAL DEFAULT NULL,
        nota2           DECIMAL DEFAULT NULL,
        nota3           DECIMAL DEFAULT NULL,
        media           DECIMAL DEFAULT NULL,
        PRIMARY KEY ( cod ),
        CONSTRAINT fk_regacadnota_disc FOREIGN KEY ( coddisciplina )
            REFERENCES disciplina ( cod ),
        CONSTRAINT fk_regacad_nota FOREIGN KEY ( codregacad )
            REFERENCES registro_academico ( cod )
        )';
    END;

END;