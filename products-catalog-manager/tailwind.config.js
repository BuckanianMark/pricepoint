/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors:{
        shiningGreen:"#01c38d",
        lightGray:"#696e79",
        darkBBlue:"#132d46",
        dark:"#191e29",
        light:"#ffffff"
      }
    },
  },
  plugins: [],
}

