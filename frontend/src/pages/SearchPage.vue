<script setup lang="ts">
import MySearch from '@/components/MySearch.vue';
import router from '@/router';
import { ref } from 'vue';

const query = ref()

const handleSearch = () => {
  router.push({
    name: 'SearchResult',
    params: {
      query: query.value,
    }
  })
}

</script>

<template>
  <div class="fixed inset-0 -z-10">
    <div 
      class="absolute inset-0 bg-[url('/images/SearchPageBackground.png')] bg-no-repeat bg-cover bg-center"
    ></div>
  </div>
  
  <div class="relative min-h-screen overflow-hidden">
    <div class="absolute top-[200px] shadow-md w-full">
      <MySearch v-model="query" @submit="handleSearch" font-size="text-7xl" placeholder="Поиск..."/>
    </div>
  </div>
</template>

<style scoped>
html, body {
  overflow: hidden;
  margin: 0;
  height: 100%;
}
</style>