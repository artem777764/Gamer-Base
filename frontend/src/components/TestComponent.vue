<script setup lang="ts">
import { ref } from 'vue'
const counter = ref(0)
const increment = () => counter.value++
</script>

<template>
  <div class="flex justify-center items-center min-h-screen bg-gray-100">
    <button
      @click="increment"
      class="px-6 py-3 bg-blue-500 text-white rounded-lg shadow-md hover:bg-blue-600 transition duration-200"
    >
      Счётчик: {{ counter }}
    </button>
  </div>
</template>