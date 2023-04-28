using JsonCreator.PropertyModels;
using JsonCreator.UserControls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonCreator
{
    public partial class MainForm : Form
    {
        List<CategoryUserControl> categories = new List<CategoryUserControl>();
        List<string> modelNames = new List<string>();
        List<string> modelPaths = new List<string>();
        List<string> texturesFolderPaths = new List<string>();
        List<string> materialsFolderPaths = new List<string>();
        Dictionary<string, List<string>> animationPaths = new Dictionary<string, List<string>>();
        string backgroundImagePath;
        bool is3DProject;

        public MainForm()
        {
            InitializeComponent();

            AddCategory(true);
            AddCategory();
        }

        public void AddCategory(bool isProjectPropertiesCategory = false)
        {
            CategoryUserControl categoryUserControl = new CategoryUserControl(isProjectPropertiesCategory);
            categoryUserControl.Dock = DockStyle.Top;
            CategoriesPanel.Controls.Add(categoryUserControl);
            categoryUserControl.BringToFront();
            //category.Height = 0;
            categories.Add(categoryUserControl);

            foreach (Control category in CategoriesPanel.Controls)
            {
                if (category.GetType() == typeof(CategoryUserControl) && !((CategoryUserControl)category).isProjectPropertiesCategory)
                    ((CategoryUserControl)category).getCategoryTitleLabel().Text = "Object #" + category.TabIndex;
            }
        }

        public void RemoveCategory(Control category)
        {
            if (categories.Count > 2)
            {
                CategoriesPanel.Controls.Remove(category);

                for (int i = 0; i < categories.Count; i++)
                    if (categories[i] == category)
                        categories.RemoveAt(i);
            }
        }

        private void CreateGamePackageButton_Click(object sender, EventArgs e)
        {
            if (PropertiesValidated())
            {
                ErrorLabel.Visible = false;
                CreatePackageZip();
            }
            else
                DisplayErrorMessage("Some inputs are left empty!");
        }

        bool PropertiesValidated()
        {
            bool valid = true;

            foreach (CategoryUserControl category in categories)
            {
                TextBox objectNameTextBox = category.getTextBox();
                Label objectNameLabel = category.getTitle();

                if (category.getTextBox().Text == "")
                {
                    valid &= false;

                    objectNameTextBox.BackColor = Color.Red;
                    objectNameTextBox.ForeColor = Color.White;
                    objectNameLabel.ForeColor = Color.Red;
                }
                else
                {
                    objectNameTextBox.BackColor = Color.White;
                    objectNameTextBox.ForeColor = Color.Black;
                    objectNameLabel.ForeColor = Color.FromArgb(0, 126, 249);
                }

                foreach (PropertyUserControl propertyUserControl in category.getFlowLayoutPanel().Controls)
                    if (propertyUserControl.Visible)
                    {
                        if (propertyUserControl.GetType() == typeof(VectorPropertyUserControl))
                        {
                            TextBox xTextBox = ((VectorPropertyUserControl)propertyUserControl).getxTextBox();
                            TextBox yTextBox = ((VectorPropertyUserControl)propertyUserControl).getyTextBox();
                            TextBox zTextBox = ((VectorPropertyUserControl)propertyUserControl).getzTextBox();

                            Label titleLabel = ((VectorPropertyUserControl)propertyUserControl).getTitle();

                            if (propertyUserControl.property.optional == false && xTextBox.Text == "" || yTextBox.Text == "" || zTextBox.Text == "")
                            {
                                valid &= false;

                                xTextBox.BackColor = Color.Red;
                                xTextBox.ForeColor = Color.White;
                                yTextBox.BackColor = Color.Red;
                                yTextBox.ForeColor = Color.White;
                                zTextBox.BackColor = Color.Red;
                                zTextBox.ForeColor = Color.White;

                                titleLabel.ForeColor = Color.Red;
                            }
                            else
                            {
                                xTextBox.BackColor = Color.White;
                                xTextBox.ForeColor = Color.Black;
                                yTextBox.BackColor = Color.White;
                                yTextBox.ForeColor = Color.Black;
                                zTextBox.BackColor = Color.White;
                                zTextBox.ForeColor = Color.Black;

                                titleLabel.ForeColor = Color.FromArgb(0, 126, 249);
                            }
                        }
                        else if (propertyUserControl.GetType() == typeof(TextPropertyUserControl))
                        {
                            TextBox textBox = ((TextPropertyUserControl)propertyUserControl).getTextBox();
                            Label titleLabel = ((TextPropertyUserControl)propertyUserControl).getTitle();

                            if (propertyUserControl.property.optional == false && textBox.Text == "")
                            {
                                valid &= false;

                                textBox.BackColor = Color.Red;
                                textBox.ForeColor = Color.White;
                                titleLabel.ForeColor = Color.Red;
                            }
                            else
                            {
                                textBox.BackColor = Color.White;
                                textBox.ForeColor = Color.Black;
                                titleLabel.ForeColor = Color.FromArgb(0, 126, 249);
                            }

                        }
                        else if (propertyUserControl.GetType() == typeof(SelectPropertyUserControl))
                        {
                            TextBox textBox = ((SelectPropertyUserControl)propertyUserControl).getTextBox();
                            Label titleLabel = ((SelectPropertyUserControl)propertyUserControl).getTitle();

                            if (propertyUserControl.property.optional == false && textBox.Text == "")
                            {
                                valid &= false;

                                textBox.BackColor = Color.Red;
                                textBox.ForeColor = Color.White;
                                titleLabel.ForeColor = Color.Red;
                            }
                            else
                            {
                                textBox.BackColor = Color.White;
                                textBox.ForeColor = Color.Black;
                                titleLabel.ForeColor = Color.FromArgb(0, 126, 249);
                            }
                        }
                    }
            }

            return valid;
        }

        void DisplayErrorMessage(string message)
        {
            ErrorLabel.Visible = true;
            ErrorLabel.Text = message;
        }

        void CreatePackageZip()
        {
            if (Directory.Exists("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator"))
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"C:/NecessaryFiles");
                SetAttributesNormal(dir);
                Directory.Delete("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator", true);
            }

            ZipFile.ExtractToDirectory("NecessaryFiles/JsonSceneGenerator.zip", "C:/NecessaryFiles/ExtractedPackage");

            //Extract("NecessaryFiles/JsonSceneGenerator.zip", "NecessaryFiles/ExtractedPackage");

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "zip files (*.zip)|*.zip",
                FilterIndex = 1,
                RestoreDirectory = true,
                FileName = "JsonSceneGenerator",
                Title = "Save Zip"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateModelsFolders();

                string startPath = "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator";
                string zipPath = Path.GetFullPath(saveFileDialog.FileName);
                File.Delete(zipPath);
                ZipFile.CreateFromDirectory(startPath, zipPath);
            }

            if (Directory.Exists("C:/NecessaryFiles"))
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"C:/NecessaryFiles");
                SetAttributesNormal(dir);
                Directory.Delete("C:/NecessaryFiles", true);
            }
        }

        internal static void SetAttributesNormal(DirectoryInfo path)
        {
            // BFS folder permissions normalizer
            Queue<DirectoryInfo> dirs = new Queue<DirectoryInfo>();
            dirs.Enqueue(path);
            while (dirs.Count > 0)
            {
                var dir = dirs.Dequeue();
                dir.Attributes = FileAttributes.Normal;
                Parallel.ForEach(dir.EnumerateFiles(), e => e.Attributes = FileAttributes.Normal);
                foreach (var subDir in dir.GetDirectories())
                    dirs.Enqueue(subDir);
            }
        }

        /*        void Extract(string zipPath, string extractPath)
                {
                    try
                    {
                        ProcessStartInfo processStartInfo = new ProcessStartInfo
                        {
                            WindowStyle = ProcessWindowStyle.Hidden,
                            FileName = Path.GetFullPath(@"7z2107-extra/7za.exe"),
                            Arguments = "x \"" + zipPath + "\" -o\"" + extractPath + "\""
                        };
                        Process process = Process.Start(processStartInfo);
                        process.WaitForExit();
                        if (process.ExitCode != 0)
                        {
                            Console.WriteLine("Error extracting {0}.", extractPath);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error extracting {0}: {1}", extractPath, e.Message);
                        throw;
                    }
                }*/

        void CreateModelsFolders()
        {
            CopyJson();
            if (!is3DProject)
                CopyBackgroundImage();
            CopyModel();
            CopyTextures();
            CopyMaterials();
            CopyAnimations();
        }

        void CopyJson()
        {
            StreamWriter writer = new StreamWriter("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Json/SceneJson.json");
            writer.Write(CreateJson());
            writer.Close();
        }

        void CopyBackgroundImage()
        {
            if (backgroundImagePath != "")
                File.Copy(backgroundImagePath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/Prefabs/Prefabs2D/Background" + Path.GetExtension(backgroundImagePath), true);
        }

        void CopyModel()
        {
            int i = 0;
            foreach (string modelPath in modelPaths)
            {
                if (modelPath != "")
                {
                    string finalFolderName = modelNames[i];
                    Directory.CreateDirectory("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + finalFolderName + "/Models");
                    File.Copy(modelPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + finalFolderName + "/Models/" + finalFolderName + Path.GetExtension(modelPath), true);

                    if (File.Exists(modelPath + ".meta"))
                        File.Copy(modelPath + ".meta", "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + finalFolderName + "/Models/" + finalFolderName + Path.GetExtension(modelPath) + ".meta", true);
                }

                i++;
            }
        }

        void CopyTextures()
        {
            int i = 0;
            foreach (string texturesFolderPath in texturesFolderPaths)
            {
                if (texturesFolderPath != "")
                {
                    string finalFolderName = modelNames[i];
                    Directory.CreateDirectory("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + finalFolderName + "/Textures");
                    CopyFilesRecursively(texturesFolderPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + finalFolderName + "/Textures");
                }

                i++;
            }
        }

        void CopyMaterials()
        {
            int i = 0;
            foreach (string materialsFolderPath in materialsFolderPaths)
            {
                if (materialsFolderPath != "")
                {
                    string finalFolderName = modelNames[i];
                    Directory.CreateDirectory("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + finalFolderName + "/Materials");
                    CopyFilesRecursively(materialsFolderPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + finalFolderName + "/Materials");
                }

                i++;
            }
        }

        void CopyAnimations()
        {
            if (is3DProject)
                Copy3DAnimations();
            else
                Copy2DAnimations();
        }

        void Copy3DAnimations()
        {
            foreach (KeyValuePair<string, List<string>> animation in animationPaths)
            {
                string modelName = animation.Key;

                Directory.CreateDirectory("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations");

                int i = 0;
                foreach (string animationPath in animation.Value)
                {
                    if (animationPath != "")
                    {
                        string finalFolderName = modelName;
                        switch (i)
                        {
                            case 0:
                                File.Copy(animationPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Idle" + Path.GetExtension(animationPath), true);
                                break;
                            case 1:
                                File.Copy(animationPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Walking" + Path.GetExtension(animationPath), true);
                                break;
                            case 2:
                                File.Copy(animationPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Running" + Path.GetExtension(animationPath), true);
                                break;
                            default:
                                File.Copy(animationPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Jumping" + Path.GetExtension(animationPath), true);
                                break;
                        }
                    }

                    i++;
                }
            }
        }

        void Copy2DAnimations()
        {
            foreach (KeyValuePair<string, List<string>> animation in animationPaths)
            {
                string modelName = animation.Key;

                Directory.CreateDirectory("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations");

                int i = 0;
                foreach (string animationFolderPath in animation.Value)
                {
                    if (animationFolderPath != "")
                    {
                        string finalFolderName = modelName;
                        switch (i)
                        {
                            case 0:
                                Directory.CreateDirectory("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Idle");
                                CopyFilesRecursively(animationFolderPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Idle");
                                break;
                            case 1:
                                Directory.CreateDirectory("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Walking");
                                CopyFilesRecursively(animationFolderPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Walking");
                                break;
                            case 2:
                                Directory.CreateDirectory("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Running");
                                CopyFilesRecursively(animationFolderPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Running");
                                break;
                            default:
                                Directory.CreateDirectory("C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Jumping");
                                CopyFilesRecursively(animationFolderPath, "C:/NecessaryFiles/ExtractedPackage/JsonSceneGenerator/JsonSceneGenerator/Resources/GameObjects/" + modelName + "/Animations/Jumping");
                                break;
                        }
                    }

                    i++;
                }
            }
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
        }

        string CreateJson()
        {
            string json = string.Empty;

            JObject newJson = new JObject();
            newJson["projectProperties"] = new JObject();
            newJson["gameObjects"] = new JObject();

            foreach (CategoryUserControl category in categories)
            {
                if (!category.isProjectPropertiesCategory)
                {
                    newJson["gameObjects"][category.getTextBox().Text] = new JObject();

                    newJson["gameObjects"][category.getTextBox().Text]["name"] = category.getTextBox().Text;
                    modelNames.Add(category.getTextBox().Text);

                    animationPaths[newJson["gameObjects"][category.getTextBox().Text]["name"].ToString()] = new List<string>();
                }

                foreach (PropertyUserControl propertyUserControl in category.getFlowLayoutPanel().Controls)
                {
                    if (propertyUserControl.Visible)
                    {
                        string propertyName = propertyUserControl.property.name.ToString();

                        if (propertyUserControl.GetType() == typeof(VectorPropertyUserControl))
                        {
                            TextBox xTextBox = ((VectorPropertyUserControl)propertyUserControl).getxTextBox();
                            TextBox yTextBox = ((VectorPropertyUserControl)propertyUserControl).getyTextBox();
                            TextBox zTextBox = ((VectorPropertyUserControl)propertyUserControl).getzTextBox();

                            JProperty x = new JProperty("x", xTextBox.Text);
                            JProperty y = new JProperty("y", yTextBox.Text);
                            JProperty z = new JProperty("z", zTextBox.Text);

                            JObject vector = new JObject(new JProperty(x), new JProperty(y), new JProperty(z));

                            if (!category.isProjectPropertiesCategory)
                                newJson["gameObjects"][category.getTextBox().Text][propertyName] = vector;
                            else
                                newJson["projectProperties"][propertyName] = vector;
                        }
                        else if (propertyUserControl.GetType() == typeof(TextPropertyUserControl))
                        {
                            TextBox textBox = ((TextPropertyUserControl)propertyUserControl).getTextBox();

                            if (!category.isProjectPropertiesCategory)
                                newJson["gameObjects"][category.getTextBox().Text][propertyName] = textBox.Text;
                            else
                                newJson["projectProperties"][propertyName] = textBox.Text;
                        }
                        else if (propertyUserControl.GetType() == typeof(ComboPropertyUserControl))
                        {
                            ComboBox comboBox = ((ComboPropertyUserControl)propertyUserControl).getComboBox();

                            if (!category.isProjectPropertiesCategory)
                                newJson["gameObjects"][category.getTextBox().Text][propertyName] = ((ComboProperty)propertyUserControl.property).options[comboBox.SelectedIndex];
                            else
                                newJson["projectProperties"][propertyName] = ((ComboProperty)propertyUserControl.property).options[comboBox.SelectedIndex];

                            if (propertyUserControl.property.name == SceneProperties.PropertyNames.dimension)
                                if (comboBox.Text == "3D")
                                    is3DProject = true;
                                else
                                    is3DProject = false;
                        }
                        else if (propertyUserControl.GetType() == typeof(SelectPropertyUserControl))
                        {
                            TextBox textBox = ((SelectPropertyUserControl)propertyUserControl).getTextBox();

                            if (propertyUserControl.property.name == SceneProperties.PropertyNames.modelPath)
                                modelPaths.Add(textBox.Text);
                            else if (propertyUserControl.property.name == SceneProperties.PropertyNames.texturesFolderPath)
                                texturesFolderPaths.Add(textBox.Text);
                            else if (propertyUserControl.property.name == SceneProperties.PropertyNames.idleAnimationPath || propertyUserControl.property.name == SceneProperties.PropertyNames.walkingAnimationPath || propertyUserControl.property.name == SceneProperties.PropertyNames.runningAnimationPath || propertyUserControl.property.name == SceneProperties.PropertyNames.jumpingAnimationPath)
                                animationPaths[newJson["gameObjects"][category.getTextBox().Text]["name"].ToString()].Add(textBox.Text);
                            else if (propertyUserControl.property.name == SceneProperties.PropertyNames.materialsFolderPath)
                                materialsFolderPaths.Add(textBox.Text);
                            else
                                backgroundImagePath = textBox.Text;
                        }
                    }
                }
            }

            json = newJson.ToString();

            return json;
        }

        static string createSampleTestJson()
        {
            string json = string.Empty;

            JArray carModels = new JArray(new string[] { "Volvo", "BMW", "Ford" });
            JProperty cars = new JProperty("cars", carModels, 5);

            JProperty gender = new JProperty("gender", new string[] { "Male", "Female" });
            JProperty hair = new JProperty("genders", new string[] { "b", "w" });
            JObject people = new JObject(new JProperty(gender), new JProperty(hair));

            JObject jObject = new JObject(new JProperty(cars), new JProperty("people", people));

            json = jObject.ToString();
            return json;
        }
    }
}
