# ProjectPuzzleGame
Перед запуском игры необходимо присоединить базу данных Puzzle к своему экземпляру СУБД. Для этого присоедините файл puzzle.mdf. 

Если Вы используете SQL Server, запустите managment studio, подключетесь к серверу, щелкните правой кнопкой мыши по базам данных, выберите пункт Присоединить, в открывшемся окне выберите файл puzzle.mdf. Нажмите ok.
В случае если Вы используете Sql Server 2012, может возникнуть ошибка из-за несовместимости версий базы данных и вашей СУБД. В этом случае, используйте скрипт puzzle.sql для генерирования базы данны. Для этого откройте puzzle.sql с помощью Вашей СУБД и нажмите выполнить.
