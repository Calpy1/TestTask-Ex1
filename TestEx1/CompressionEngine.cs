using System.Text;

namespace TestEx1
{
    class CompressionEngine
    {
        private string _userText;
        public CompressionEngine(string text) //Исходная строка для обработки
        {
            _userText = text;
        }

        public string Compression()
        {
            if (string.IsNullOrEmpty(_userText)) //Проверка на пустую строку
            {
                return $"Null or Empty string cannot be compressed";
            }

            StringBuilder compressed = new StringBuilder();
            char currentChar = _userText[0]; //Текущий символ
            int counter = 1; //Счетчик повторений символа

            for (int i = 1; i < _userText.Length; i++) //Проходим по строке со второго символа
            {
                if (_userText[i] == currentChar)
                {
                    counter++; //Если символ совпадает - увеличиваем счетчик
                    continue;
                }

                compressed.Append(currentChar); //Если символ поменялся - добавляем в строку

                if (counter > 1) //Если символов больше, чем один - добавляем к нему счетчик
                {
                    compressed.Append(counter);
                }

                currentChar = _userText[i]; //Обновляем символ и сбрасываем счетчик
                counter = 1;
            }

            //Записываем последний символ и количество повторений
            compressed.Append(currentChar);
            if (counter > 1)
            {
                compressed.Append(counter);
            }

            return compressed.ToString();
        }

        public string Decompression()
        {
            if (string.IsNullOrEmpty(_userText)) //Проверка на пустую строку
            {
                return $"Null or Empty string cannot be decompressed";
            }

            StringBuilder decompressedText = new StringBuilder();
            char currentChar = _userText[0]; //Текущий символ
            int counter = 0; //Счетчик повторений символа


            if (char.IsDigit(_userText[0])) //Проверка на начало строки с цифры
            {
                return $"A string \"{_userText}\" cannot start with a digit";
            }

            //Проходим по каждому символу сжатой строки
            for (int i = 0; i < _userText.Length; i++)
            {
                if (char.IsLetter(_userText[i]))
                {
                    currentChar = _userText[i]; //Если буква - новый текущий символ

                    if (i + 1 >= _userText.Length || !char.IsDigit(_userText[i + 1])) //Если за ней нет цифры - добавляем один раз
                    {
                        decompressedText.Append(currentChar);
                        continue;
                    }
                }

                if (char.IsDigit(_userText[i])) //Если цифра - считаем повторения
                {
                    counter = 0;

                    if (i + 1 < _userText.Length && char.IsDigit(_userText[i + 1])) //Проверка на двузначное число
                    {
                        string numberStr = _userText[i].ToString() + _userText[i + 1].ToString();
                        counter = int.Parse(numberStr);
                        decompressedText.Append(new string(currentChar, counter)); //Добавляем текущий символ counter раз

                        i++; //Пропускаем текущий символ, его посчитали
                        continue;
                    }
                    else
                    {
                        counter = int.Parse(_userText[i].ToString()); //если однозначное число
                        decompressedText.Append(new string(currentChar, counter));
                    }
                }
            }

            return decompressedText.ToString();
        }
    }
}
