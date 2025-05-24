<script setup lang="ts">
import { onMounted, ref, watch } from 'vue';
import axios from 'axios'
import MyInput from '@/components/ui/MyInput.vue';
import GameCard from '@/components/GameCard.vue';

const name = ref('')

interface Game {
  Id: number
  ImageURL: string
}

const games = ref<Game[]>([])


let debounceTimeout: number | undefined
watch(name, (newName: string) => {
  clearTimeout(debounceTimeout)

  debounceTimeout = window.setTimeout(() => {
    fetchGames(newName)
  }, 200)
})

async function fetchGames(name: string){
    try {
        const response = await axios.post(
        'http://localhost:5007/Games/Search',
        {
            Name: name
        },
        {
            params: {
                page: 1,
                size: 8
            }
        });
        games.value = response.data;
    } catch (error) {
        console.error('Ошибка при загрузке игр:', error);
    }
}

onMounted(() => {
  fetchGames(name.value)
})

</script>

<template>
    <div class="min-h-screen bg-background">
        <div class="px-5 pt-5">
            <MyInput v-model="name" background-color="bg-secondary" font-size="text-5xl" placeholder="Поиск..." class="w-full"></MyInput>
        </div>
        <div class="grid grid-cols-4 gap-x-5 px-5 pt-5">
            <router-link
                v-for="game in games"
                :key="game.Id"
                :to="`/game-info/${game.Id}`"
                class="mb-5 w-full block"
            >
                <GameCard :image-src="game.ImageURL" class="w-full" />
            </router-link>
        </div>
    </div>
</template>