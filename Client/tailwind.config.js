/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        primary:'#01040d',
        light:'#222',
        secondary:'#676b75',
        brightorange:'#f0651a',
        darkblue:"#51388a",
        blue:"#14063b"
      }
    },
  },
  plugins: [],
}

