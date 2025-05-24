<script setup lang="ts">
import { onMounted, ref } from 'vue';
import axios from 'axios'
import GameCard from '@/components/GameCard.vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const id = route.params.id as string

interface Game {
  Id: number
  ImageURL: string
}

const game = ref<Game>()
async function fetchGameInfo(id: string)
{
    try {
        const response = await axios.get(`http://localhost:5007/Games/${id}`)
        game.value = response.data
    } catch (error) {
        console.error('Ошибка при загрузке игры:', error);
    }
}

onMounted(() => {
    fetchGameInfo(id)
})
</script>

<template>
    <div class="min-h-screen bg-background px-5 pt-5">
        <div v-if="game">
            <GameCard :image-src="game.ImageURL" class="w-1/4" />
        </div>
    </div>
</template>