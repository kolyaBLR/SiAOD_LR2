using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAOD_LR2
{
    class HashList
    {
        public string key { get; set; }
        public string text { get; set; }
        public HashList Next { get; set; }
        public HashList Back { get; set; }

        public HashList() { }

        public HashList(string key, string text)
        {
            this.key = key;
            this.text = text;
        }
    }

    class MyList
    {
        private HashList hash;

        public MyList() { hash = new HashList(); }

        //функция добавление нового слова
        public void add(string key, string text)
        {
            /* Уходим в начало списка.
             * Если при проверочном поиске нашли ключ то делаем перезапись.
             * Иначе переходим в конец списка.
             * И производим запись.
             */
            reverseBegin();
            if (searchKey(key).key == key)
            {
                hash.key = key;
                hash.text = text;
            }
            else
            {
                reverseEnd();
                HashList local = new HashList(key, text);
                local.Back = hash;
                hash.Next = local;
                hash = local;
            }
        }

        //метод поиска по ключу
        public HashList searchKey(string key)
        {
            /* Этот метод волшебный, и он
             * гарантированно возвращает целый список
             * И при вызове метода
             * нужно всего лишь проверить совпадают ли ключи
             */
            reverseBegin();
            while (hash.Next != null)
            {
                if (hash.key == key)
                    return hash;
                hash = hash.Next;
            }
            return hash;
        }

        //метод удаления элемента из списка
        public void delete(string key)
        {
            /* Если элемент списка не является последним
             * то вырезаем его путём создания буферной переменной
             * иначе просто удаляем ссылки на этот последний элемент
             */
            searchKey(key);
            if (hash.Next != null && hash.Back != null)
            {
                HashList local = hash.Next;
                local.Back = hash.Back;
                hash.Back.Next = local;
                hash = local;
            }
            else
            if (hash.Next == null)
                hash.Back.Next = null;
        }

        //функция для перехода к концу списка
        public void reverseEnd()
        {
            while (hash.Next != null)
            {
                hash = hash.Next;
            }
        }

        //функция для перехода к началу списка
        public void reverseBegin()
        {
            while (hash.Back != null)
            {
                hash = hash.Back;
            }
            if (hash.Back != null && hash.Next != null)
                hash = hash.Next;
        }
    }
}
