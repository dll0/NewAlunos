BEGIN
    INSERT ALL
       INTO cidade (codigo, nome, uf) VALUES (1, 'Caxias do Sul', 'RS')
       INTO cidade (codigo, nome, uf) VALUES (2, 'São Paulo', 'SP')
       INTO cidade (codigo, nome, uf) VALUES (3, 'Porto Alegre', 'RS')
    SELECT 1 FROM DUAL;
    
    INSERT ALL
        /* Caxias do Sul */
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (1, 'Matheus', 'Oliveira', 1, '50373023316', to_date('25/05/2000', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (2, 'Ricardo', 'Pereira', 1, '81631349414', to_date('12/01/1998', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (3, 'Israr', 'Ortega', 1, '85803412562', to_date('22/02/1997', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (4, 'Krish', 'Malone', 1, '50083677305', to_date('01/02/2001', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (5, 'Esmae', 'Lyon', 1, '23670202480', to_date('12/12/1974', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (6, 'Amanda', 'Buckley', 1, '62581282207', to_date('02/12/2000', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (7, 'Kaylie', 'Coulson', 1, '65050691001', to_date('07/06/1986', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (8, 'Manahil', 'Piper', 1, '67462142147', to_date('16/12/1991', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (9, 'Jesus', 'Ali', 1, '12795001403', to_date('08/03/1998', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (10, 'Ivor', 'Joyce', 1, '16486259329', to_date('23/10/2000', 'DD/MM/YYYY'))
       /* São Paulo */
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (11, 'Deacon', 'Redman', 2, '08780921299', to_date('19/04/1986', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (12, 'Garrett', 'Farrell', 2, '51412833566', to_date('28/01/1987', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (13, 'Rihanna', 'Muir', 2, '68817280348', to_date('23/10/1987', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (14, 'Gurveer', 'Martin', 2, '18814517479', to_date('31/10/1987', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (15, 'Ephraim', 'Lara', 2, '43188131186', to_date('24/12/1988', 'DD/MM/YYYY'))
       /* Porto Alegre */
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (16, 'Mai', 'Mccann', 3, '53812347830', to_date('19/04/1986', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (17, 'Addison', 'Rigby', 3, '11280476168', to_date('28/01/1987', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (18, 'Wilf', 'Allan', 3, '58526457292', to_date('26/07/1987', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (19, 'Jade', 'Perkins', 3, '32764022549', to_date('31/10/1987', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (20, 'Melissa', 'Dillard', 3, '28097801965', to_date('26/07/1987', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (21, 'Sonnie', 'Ahmed', 3, '16213314660', to_date('31/10/1987', 'DD/MM/YYYY'))
       INTO aluno (codigo, nome, sobrenome, codcidade, cpf, datanascimento) VALUES (22, 'Mia-Rose', 'Fenton', 3, '70730942902', to_date('24/12/1988', 'DD/MM/YYYY'))
    SELECT 1 FROM DUAL;
    
    INSERT ALL
       INTO curso (cod, nome, datainicio, cargahoraria) VALUES (1, 'Análise e Desenvolvimento de Sistemas', to_date('03/05/2019', 'DD/MM/YYYY'), 200)
       INTO curso (cod, nome, datainicio, cargahoraria) VALUES (2, 'Engenharia da Computação', to_date('03/05/2019', 'DD/MM/YYYY'), 400)
       INTO curso (cod, nome, datainicio, cargahoraria) VALUES (3, 'Ciência da Computação', to_date('03/05/2019', 'DD/MM/YYYY'), 500)
    SELECT 1 FROM DUAL;
    
    INSERT ALL
       INTO disciplina (cod, nome, valor) VALUES (1, 'Programação Orientada a Objetos I', 10)
       INTO disciplina (cod, nome, valor) VALUES (2, 'Estrutura de Dados', 10)
       INTO disciplina (cod, nome, valor) VALUES (3, 'Arquitetura e Protocolo de Redes', 10)
       INTO disciplina (cod, nome, valor) VALUES (4, 'Gestão Estratégica da Informação', 10)
       INTO disciplina (cod, nome, valor) VALUES (5, 'Matemática', 10)
    SELECT 1 FROM DUAL;
    
    INSERT ALL
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (1, 0251102, '2º', 1, 1)
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (2, 0321311, '1º', 2, 3)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (3, 0645666, '4º', 3, 2)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (4, 0654645, '5º', 4, 1)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (5, 0232212, '1º', 5, 1)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (6, 0232323, '2º', 6, 3)
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (7, 0314144, '3º', 7, 2)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (8, 0232313, '4º', 8, 1)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (9, 0231313, '5º', 9, 3)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (10, 0251312, '2º', 10, 1)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (11, 0212313, '2º', 11, 1)
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (12, 0275675, '3º', 12, 1)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (13, 0978979, '1º', 13, 1)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (14, 0321313, '3º', 14, 2)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (15, 0123133, '4º', 15, 3)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (16, 0414144, '7º', 16, 3)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (17, 0434535, '2º', 17, 3)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (18, 0546456, '4º', 18, 1)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (19, 0646436, '6º', 19, 2)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (20, 0636366, '2º', 20, 2)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (21, 0363636, '3º', 21, 1)  
       INTO registro_academico (cod, numero_matricula, semestre, cod_aluno, cod_curso) VALUES (22, 0343434, '4º', 22, 2)  
    SELECT 1 FROM DUAL;
    
    INSERT ALL
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (1, 1, 1)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (2, 1, 2)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (3, 1, 4)
       
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (4, 2, 2)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (5, 2, 3)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (6, 2, 4)
       
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (7, 3, 1)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (8, 3, 3)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (9, 3, 5)
       
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (10, 4, 3)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (11, 4, 1)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (12, 4, 4)
       
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (13, 5, 5)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (14, 5, 3)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (15, 5, 4)
       
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (16, 6, 2)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (17, 6, 3)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (18, 6, 4)
       
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (19, 7, 3)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (20, 7, 2)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (21, 7, 4)
       
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (22, 8, 3)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (23, 8, 2)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (24, 8, 4)
       
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (25, 9, 1)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (26, 9, 2)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (27, 9, 4)
       
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (28, 10, 1)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (29, 10, 2)
       INTO registro_academico_disciplina (cod, cod_reg_academico, cod_disciplina) VALUES (30, 10, 4)
    SELECT 1 FROM DUAL;
END;