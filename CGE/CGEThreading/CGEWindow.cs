using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;

using CGE.CGE;

namespace CGE.CGEThreading
{
    internal class CGEWindow
    {
        public IWindow window;
        public IInputContext input;
        public GL GL;
        public string title;

        public List<CGEGameObject> gameObjects = new List<CGEGameObject>();

        public uint program;

        public CGEWindow(string _title)
        {
            title = _title;

            WindowOptions options = WindowOptions.Default;
            options.Title = title;
            options.Size = new Vector2D<int>(1280, 720);
            window = Window.Create(options);

            window.Load   += OnWindowOnLoad;
            window.Update += OnWindowOnUpdate;
            window.Render += OnWindowOnRender;
        }
        public void Run() { window.Run(); }

        private void OnWindowOnLoad()
        {
            input = window.CreateInput();
            GL    = window.CreateOpenGL();

            foreach (IMouse mouse in input.Mice)
            {
                mouse.Click += (IMouse cursor, MouseButton button, System.Numerics.Vector2 pos) =>
                {
                    Console.WriteLine("Clicked");
                };
            }

            GL.ClearColor(0.416f, 0.555f, 0.700f, 1.0f);

            uint vShader = GL.CreateShader(ShaderType.VertexShader);
            uint fShader = GL.CreateShader(ShaderType.FragmentShader);
            
            GL.ShaderSource(vShader, gameObjects[0].VertexShader);
            GL.ShaderSource(fShader, gameObjects[0].FragmentShader);
            GL.CompileShader(vShader);
            GL.CompileShader(fShader);

            program = GL.CreateProgram();
            GL.AttachShader(program, vShader);
            GL.AttachShader(program, fShader);
            GL.LinkProgram(program);
            GL.DetachShader(program, vShader);
            GL.DetachShader(program, fShader);
            GL.DeleteShader(vShader);
            GL.DeleteShader(fShader);

            // Debug shaders
            GL.GetProgram(program, GLEnum.LinkStatus, out var status);
            if(status == 0) { Console.WriteLine($"Error linking shader {GL.GetProgramInfoLog(program)}"); }
        }

        private void OnWindowOnUpdate(double d)
        {
        }

        private unsafe void OnWindowOnRender(double d)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach (var gameObject in gameObjects)
            {
                uint vao = GL.GenVertexArray();
                GL.BindVertexArray(vao);

                uint vertices = GL.GenBuffer();
                uint colors = GL.GenBuffer();
                uint indices = GL.GenBuffer();

                GL.BindBuffer(GLEnum.ArrayBuffer, vertices);
                GL.BufferData(GLEnum.ArrayBuffer, (ReadOnlySpan<float>)gameObject.Vertices.ToArray().AsSpan(), GLEnum.StaticDraw);
                GL.VertexAttribPointer(0, 3, GLEnum.Float, false, 0, null);
                GL.EnableVertexAttribArray(0);

                GL.BindBuffer(GLEnum.ArrayBuffer, colors);
                GL.BufferData(GLEnum.ArrayBuffer, (ReadOnlySpan<float>)gameObject.ColorArr.ToArray().AsSpan(), GLEnum.StaticDraw);
                GL.VertexAttribPointer(1, 4, GLEnum.Float, false, 0, null);
                GL.EnableVertexAttribArray(1);

                GL.BindBuffer(GLEnum.ElementArrayBuffer, indices);
                GL.BufferData(GLEnum.ElementArrayBuffer, (ReadOnlySpan<uint>)gameObject.IndexArray.ToArray().AsSpan(), GLEnum.StaticDraw);

                GL.BindBuffer(GLEnum.ArrayBuffer, 0);
                GL.UseProgram(program);

                GL.DrawElements(GLEnum.Triangles, 3, GLEnum.UnsignedInt, null);

                GL.BindBuffer(GLEnum.ElementArrayBuffer, 0);
                GL.BindVertexArray(vao);

                GL.DeleteBuffer(vertices);
                GL.DeleteBuffer(colors);
                GL.DeleteBuffer(indices);
                GL.DeleteVertexArray(vao);
            }
            
        }
    }
}
