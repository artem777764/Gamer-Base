/** @type {import('tailwindcss').Config} */
import { type Config } from 'tailwindcss'
import colors from 'tailwindcss/colors'

const config: Config = {
  content: ['./index.html', './src/**/*.{vue,js,ts}'],
  theme: {
    extend: {
      colors: {
        primary: '#1e40af', // тёмно-синий
        secondary: '#64748b', // серо-синий
        accent: '#f59e0b', // жёлто-оранжевый
        background: '#f8fafc', // светлый фон
        danger: colors.rose['600'], // пример использования встроенных цветов tailwind
      },
    },
  },
  plugins: [],
}

export default config
