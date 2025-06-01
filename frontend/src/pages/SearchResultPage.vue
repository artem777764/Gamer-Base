<script setup lang="ts">
import { onMounted, ref, watch } from 'vue';
import axios from 'axios'
import Card from '@/components/Card.vue';
import MySearch from '@/components/MySearch.vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const name = ref(route.params.query as string)

interface Game {
  Id: number
  Rating: number,
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
                size: 4
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
        <MySearch v-model="name" font-size="text-5xl" placeholder="Поиск..."/>
        <div class="grid grid-cols-2 gap-x-5 px-5 pt-5">
            <div v-for="game in games"
                :key="game.Id"
                :to="`/game-info/${game.Id}`"
                class="mb-5 w-full block">
                <router-link :to="`/game-info/${game.Id}`">
                    <Card :image-src="game.ImageURL" class="w-full"/>
                </router-link>
                <div v-if="game.Rating">
                    <router-link :to="{ name: 'GameReview', params: { id: game.Id } }">
                        <p class="font-russo leading-none text-shadow text-white text-3xl underline mt-1 text-center">{{game.Rating.toFixed(2)}}/5.00</p>
                    </router-link>
                </div>
                <div v-else>
                    <router-link :to="{ name: 'GameReview', params: { id: game.Id } }">
                        <p class="font-russo leading-none text-shadow text-gray-400 text-3xl underline mt-1 text-center">Нет отзывов</p>
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>