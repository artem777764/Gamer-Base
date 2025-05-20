/** @type {import('tailwindcss').Config} */
import { type Config } from 'tailwindcss'
import colors from 'tailwindcss/colors'

const config: Config = {
  content: ['./index.html', './src/**/*.{vue,js,ts}'],
  theme: {
    extend: {
      fontFamily: {
        russo: ['"Russo One"', 'sans-serif'],
      },
      colors: {
        primary: '#154D66',
        secondary: '#143747',
        background: '#132F3B',
      },
    },
  },
  plugins: [],
}

export default config