/** @type {import('tailwindcss').Config} */
import { type Config } from 'tailwindcss'
import colors from 'tailwindcss/colors'
import aspectRatio from '@tailwindcss/aspect-ratio'

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
  plugins: [
    aspectRatio,
  ],
}

export default config