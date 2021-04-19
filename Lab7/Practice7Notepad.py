import unittest
from datetime import datetime

class MainScreen:

    LOCATOR = "LOCATOR.png"
    LOCATOR_FILE = "LOCATOR_FILE.png"
    LOCATOR_SAVE = "LOCATOR_SAVE.png"
    LOCATOR_SAVE_AS = "SAVE_AS.png"  
    LOCATOR_OPEN = "LOCATOR_OPEN.png"

    def ClickDiscord(self):
        Sikuli.click(self.LOCATOR)
        
    def ClickFile(self):
        Sikuli.click(self.LOCATOR_FILE)

    def ZoomPlus(self):
        Sikuli.type(Key.ADD, KeyModifier.CTRL)
        
    def ZoomMinus(self):
        Sikuli.type(Key.MINUS, KeyModifier.CTRL)
    
    def ClickOpen(self):
        Sikuli.click(self.LOCATOR_OPEN)

    def ClickSave(self):
        Sikuli.click(self.LOCATOR_SAVE)
        
    def ClickSaveAs(self):
        Sikuli.click(self.LOCATOR_SAVE_AS)
      
    def TypeText(self,text):
        Sikuli.type("a", KeyModifier.CTRL)
        Sikuli.type(Key.BACKSPACE)
        Sikuli.type(text);

class OpenMenuScreen:
    LOCATOR_OPEN = "OPEN.png"

    def ClickOpen(self):
        click(self.LOCATOR_OPEN)

    def TypePath(self,text):
        Sikuli.type("a", KeyModifier.CTRL)
        Sikuli.type(Key.BACKSPACE)
        Sikuli.type(text);

class SaveMenuScreen:
   LOCATOR_SAVE = "SAVE.png"
   
   def ClickSave(self):
        click(self.LOCATOR_SAVE)

   def TypePath(self,text):
       date_time = datetime.now().strftime("%m-%d-%Y_%H-%M-%S")
       
       Sikuli.type("a", KeyModifier.CTRL)
       Sikuli.type(Key.BACKSPACE)

       path = text + date_time + ".txt"
       Sikuli.type(path);



class Test(unittest.TestCase):
    
    myApp = App("C:\\WINDOWS\\system32\\notepad.exe")
    main_screen = MainScreen()
    open_menu_screen = OpenMenuScreen()
    save_menu_screen = SaveMenuScreen()
    
    def setUp(self):
        self.myApp.open()

    def testZoom(self):
        wait(1)
        self.main_screen.ZoomPlus()
   
        wait(1)
        self.main_screen.ZoomMinus()
        wait(1)
        

    def test(self):

        
        self.main_screen.ClickFile()
        self.main_screen.ClickOpen()

        wait(1)

        self.open_menu_screen.TypePath("C:\Users\volod\Desktop\mytext.txt")
        self.open_menu_screen.ClickOpen()


        self.main_screen.TypeText("Test 1")

        self.main_screen.ClickFile()
        self.main_screen.ClickSave()

        self.main_screen.TypeText("Test 2")

        self.main_screen.ClickFile()
        self.main_screen.ClickSaveAs()

        wait(1)
        
        self.save_menu_screen.TypePath("Test 3")
        self.save_menu_screen.ClickSave()

        wait(1)
        

    def tearDown(self):
        self.myApp.close()


if __name__ == '__main__':
    try:
      unittest.main()
    except SystemExit as inst:
        if inst.args[0] is True:
            raise