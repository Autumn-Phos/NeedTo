# **ИЗМЕНЕНИЯ**

## Добавлен **UpdateLog**

## Изменена организация директории **CustomLibrary**

* Каждая библиотека обзавелась собственной директорией

## Изменен **ToastMaker**

* **ToastMaker** теперь библиотека - **ToastFactory**
* Добавлена очередь тоастов.
* Удалены анимации исчезновения тоаста созданные при помощи Unity animations/animator в рамках оптимизации.
* Добавлена анимация исчезновения тоаста через код см файл [ToastMaker](Assets\Scripts\CustomLibrary\ToastMaker\ToastMaker.cs) 76 строка.

## Изменен **ChangeFrame**: скрипт для смены активных окон

* Добавлена возможность выбрать способ загрузки окна (Standart/WithLoadingScripts)
    * **Standart:**  Этот способ загрузки окна не требует дополнительных скриптов, окно активируется напрямую.
    * **WithLoadingScripts:** Этот способ загрузки окна использует дополнительные скрипты для обработки загрузки (StartLoadFrame) см файл [LoadFrame](Assets/Scripts/CustomLibrary/FrameLoader/LoadFrame.cs).