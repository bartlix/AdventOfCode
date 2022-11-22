namespace Day15
{
    internal class IngredientsInfo
    {
        public IngredientsInfo(string input)
        {
            Parse(input);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Calories { get; private set; }

        public int Texture { get; private set; }

        public int Flavor { get; private set; }

        public int Durability { get; private set; }

        private void Parse(string input)
        {
            var parts = input.Split(':');

            Name = parts[0];

            parts = parts[1].Trim().Split(',');

            foreach (var part in parts)
            {
                var keyValue = part.Trim().Split(' ');

                if (keyValue[0] == "capacity")
                {
                    Capacity = int.Parse(keyValue[1]);
                }

                if (keyValue[0] == "durability")
                {
                    Durability = int.Parse(keyValue[1]);
                }

                if (keyValue[0] == "flavor")
                {
                    Flavor = int.Parse(keyValue[1]);
                }

                if (keyValue[0] == "texture")
                {
                    Texture = int.Parse(keyValue[1]);
                }

                if (keyValue[0] == "calories")
                {
                    Calories = int.Parse(keyValue[1]);
                }
            }
        }
    }
}